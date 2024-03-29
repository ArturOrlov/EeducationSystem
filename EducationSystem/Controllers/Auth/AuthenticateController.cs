﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EducationSystem.Dto;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using Role = EducationSystem.Entities.DbModels.Identity.Role;

namespace EducationSystem.Controllers.Auth;

[ApiController]
[Route("api/authenticate")]
public class AuthenticateController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<Role> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly IAccountService _accountService;
    private readonly ISettingService _settingService;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public AuthenticateController(
        UserManager<User> userManager,
        RoleManager<Role> roleManager,
        IConfiguration configuration,
        IUserService userService,
        IAccountService accountService,
        ISettingService settingService,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _configuration = configuration;
        _userService = userService;
        _accountService = accountService;
        _settingService = settingService;
        _refreshTokenRepository = refreshTokenRepository;
    }

    [HttpPost]
    [Route("login")]
    [SwaggerOperation(
        Summary = "Авторизация пользователя",
        Description = "Авторизация пользователя",
        OperationId = "Account.Login",
        Tags = new[] { "Account" }
    )]
    public async Task<IActionResult> Login([FromBody] LoginDto model)
    {
        var user = await _userService.GetByLoginAsync(model.Login, model.Password);

        if (user.IsError)
        {
            return BadRequest(user.Description);
        }

        var userRoles = await _userManager.GetRolesAsync(user.Data);

        var authClaims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Data.UserName),
            new(ClaimTypes.NameIdentifier, user.Data.Id.ToString()),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var token = CreateToken(authClaims);
        var refreshToken = GenerateRefreshToken();

        _ = int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out int refreshTokenValidityInDays);

        // user.Data.RefreshToken = refreshToken;
        // user.Data.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays);

        user.Data.UpdatedAt = DateTime.Now;
        await _userManager.UpdateAsync(user.Data);

        return Ok(new
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            RefreshToken = refreshToken,
            Expiration = token.ValidTo
        });
    }

    // [HttpPost]
    // [Route("refresh-token")]
    // public async Task<IActionResult> RefreshToken(BaseAuth tokenModel)
    // {
    //     string? accessToken = tokenModel.AccessToken;
    //     string? refreshToken = tokenModel.RefreshToken;
    //     
    //     var principal = GetPrincipalFromExpiredToken(accessToken);
    //     
    //     if (principal == null)
    //     {
    //         return BadRequest("Invalid access token or refresh token");
    //     }
    //     
    //     string username = principal.Identity.Name;
    //     
    //     var user = await _userManager.FindByNameAsync(username);
    //     
    //     if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
    //     {
    //         return BadRequest("Invalid access token or refresh token");
    //     }
    //     
    //     var newAccessToken = CreateToken(principal.Claims.ToList());
    //     var newRefreshToken = GenerateRefreshToken();
    //     
    //     user.RefreshToken = newRefreshToken;
    //     user.UpdatedAt = DateTime.Now;
    //     await _userManager.UpdateAsync(user);
    //     
    //     return new ObjectResult(new
    //     {
    //         accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
    //         refreshToken = newRefreshToken
    //     });
    // }

    // [Authorize]
    // [HttpPost]
    // [Route("revoke/{username}")]
    // public async Task<IActionResult> Revoke(string username)
    // {
    //     var user = await _userManager.FindByNameAsync(username);
    //     
    //     if (user == null)
    //     {
    //         return BadRequest("Invalid user name");
    //     }
    //     
    //     user.RefreshToken = null;
    //     user.UpdatedAt = DateTime.Now;
    //     await _userManager.UpdateAsync(user);
    //
    //     return Ok();
    // }
    //
    // [Authorize]
    // [HttpPost]
    // [Route("revoke-all")]
    // public async Task<IActionResult> RevokeAll()
    // {
    //     var users = _userManager.Users.ToList();
    //     
    //     foreach (var user in users)
    //     {
    //         user.RefreshToken = null;
    //         user.UpdatedAt = DateTime.Now;
    //         await _userManager.UpdateAsync(user);
    //     }
    //
    //     return Ok();
    // }

    private JwtSecurityToken CreateToken(List<Claim> authClaims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
        );

        return token;
    }

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }
}