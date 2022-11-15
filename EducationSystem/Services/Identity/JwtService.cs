using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Identity;

namespace EducationSystem.Services.Identity;

public class JwtService : IJwtService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ISettingService _settings;

    public JwtService(UserManager<User> userManager, 
        IConfiguration configuration, 
        ISettingService settings)
    {
        _userManager = userManager;
        _configuration = configuration;
        _settings = settings;
    }

    // private async Task<string> GenerateJwtTokenAsync(User user)
    // {
    //     var userRoles = await _userManager.GetRolesAsync(user);
    //
    //     var authClaims = new List<Claim>
    //     {
    //         new(ClaimTypes.Name, user.UserName),
    //         new(ClaimTypes.NameIdentifier, user.Id.ToString()),
    //         new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    //     };
    //
    //     foreach (var userRole in userRoles)
    //     {
    //         authClaims.Add(new Claim(ClaimTypes.Role, userRole));
    //     }
    //
    //     // Достаем из appsettings.json
    //     var jwtAppSettingOptions = _configuration.GetSection("JwtOptions");
    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtAppSettingOptions["JwtKey"]));
    //     var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //     var tokenHoursLife = await _settings.GetInt(EducationSystemSettings.JWT_TOKEN_HOURS);
    //     var expires = DateTime.UtcNow.AddHours(Convert.ToDouble(tokenHoursLife));
    //
    //     var token = new JwtSecurityToken(
    //         jwtAppSettingOptions["JwtIssuer"],
    //         jwtAppSettingOptions["JwtIssuer"],
    //         expires: expires,
    //         signingCredentials: credentials
    //     );
    //
    //     return new JwtSecurityTokenHandler().WriteToken(token);
    // }
    //
    // private string GenerateRefreshToken()
    // {
    //     using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
    //     {
    //         var randomBytes = new byte[64];
    //         rngCryptoServiceProvider.GetBytes(randomBytes);
    //         var token = Convert.ToBase64String(randomBytes);
    //         return token;
    //     }
    // }
    //
    // public async Task<UserJwtTokens> CreateTokens(Device device)
    // {
    //     CheckDevice(device);
    //     
    //     var user = await _userManager.FindByIdAsync(device.UserId.ToString());
    //
    //     var tokens = new UserJwtTokens();
    //     
    //     //Создаем JWToken
    //     var jwtToken = await GenerateJwtTokenAsync(user);
    //     tokens.JwtToken = jwtToken;
    //     
    //     //Создаем уникальный RefreshToken
    //     var newRefreshTokenString = GenerateRefreshToken();
    //    
    //     while (_db.Repos.RefreshToken.FindByToken(newRefreshTokenString) != null)
    //     {
    //         newRefreshTokenString = GenerateRefreshToken();
    //     }
    //     
    //     var existedRefresh = _db.Repos.RefreshToken.GetByDeviceId(device.Id);
    //
    //     if (existedRefresh != null)
    //     {
    //         existedRefresh.Token = newRefreshTokenString;
    //         existedRefresh.ExpireTime = DateTime.Now.AddHours(await _settings.GetInt(EducationSystemSettings.JWT_REFRESH_HOURS));
    //         await _db.SaveChangesAsync();
    //         tokens.RefreshToken = newRefreshTokenString;
    //         return tokens;
    //     }
    //
    //     var refreshExpiresTime = DateTime.Now.AddHours(await _settings.GetInt(EducationSystemSettings.JWT_REFRESH_HOURS));
    //     var newRefreshToken = new RefreshToken(newRefreshTokenString, device.Id, refreshExpiresTime);
    //     await _db.Repos.RefreshToken.AddAsync(newRefreshToken);
    //     await _db.SaveChangesAsync();
    //     tokens.RefreshToken = newRefreshTokenString;
    //     return tokens;
    // }
        
    // public async Task<UserJwtTokens> UpdateTokens(string refreshToken)
    // {
    //
    //     var existedRefreshToken = _db.Repos.RefreshToken.FindByToken(refreshToken);
    //
    //     if (existedRefreshToken == null)
    //     {
    //         return null;
    //     }
    //
    //     if (existedRefreshToken.ExpireTime < DateTime.Now)
    //     {
    //         return null;
    //     }
    //
    //     var user = _db.Repos.RefreshToken.GetUserByTokenId(existedRefreshToken.Id);
    //
    //     var jwt = await GenerateJwtTokenAsync(user);
    //     
    //     var refresh = GenerateRefreshToken();
    //     existedRefreshToken.Token = refresh;
    //     existedRefreshToken.ExpireTime = DateTime.Now.AddHours(await _settings.GetInt(EducationSystemSettings.JWT_REFRESH_HOURS));
    //     await _db.SaveChangesAsync();
    //
    //     var tokens = new UserJwtTokens()
    //     {
    //         JwtToken = jwt,
    //         RefreshToken = refresh,
    //     };
    //
    //     return tokens;
    // }
    //
    // public async Task DeleteTokens(Device device)
    // {
    //     CheckDevice(device);
    //     
    //     var existedRefreshToken = _db.Repos.RefreshToken.GetByDeviceId(device.Id);
    //     if (existedRefreshToken != null)
    //     {
    //         await _db.Repos.RefreshToken.DeleteAsync(existedRefreshToken);
    //         await _db.SaveChangesAsync();
    //     }
    // }
    //
    // private void CheckDevice(Device device)
    // {
    //     if (device == null || device.Id == default || device.UserId == default)
    //     {
    //         throw new Exception("Device должен существовать в БД");
    //     }
    // }
}