using System.Security.Claims;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Identity;

namespace EducationSystem.Services.Identity;

public class UserClaimService : IUserClaimService
{
    private readonly UserManager<User> _userManager;
    private readonly IUserService _userService;
    private readonly IClaimService _claimService;
    private readonly IUserClaimRepository _userClaimRepository;

    public UserClaimService(UserManager<User> userManager,
        IUserService userService, 
        IClaimService claimService, 
        IUserClaimRepository userClaimRepository)
    {
        _userManager = userManager;
        _userService = userService;
        _claimService = claimService;
        _userClaimRepository = userClaimRepository;
    }

    public async Task<BaseResponse<List<string>>> GetListClaimByUserIdAsync(int userId)
    {
        var response = new BaseResponse<List<string>>();
        var list = new List<string>();
        
        // var user = await _userManager.FindByIdAsync(userId.ToString());
        //
        // if (user == null)
        // {
        //     response.IsError = true;
        //     response.Description = $"Пользователь с id - {userId} не найден";
        //     return response;
        // }
        //
        // var listClaims = await _userService.GetRangeClaims(userId);
        // var listClaims = new QueryFactory(_connection, _compiler)
        //     .Query("identity.UserClaim as uc")
        //     .Select("uc.Id as Id", "uc.UserId as UserId", "uc.ClaimType as ClaimType",
        //         "uc.ClaimValue as ClaimValue").Where("uc.UserId", id)
        //     .Get<UserClaimDTO>()
        //     .ToList();
        //
        // if (!listClaims.Any())
        // {
        //     response.IsError = true;
        //     response.Description = "claims не найдены";
        //     return response;
        // }

        // response.Data = listClaims;
        response.Data = list;
        return response;
    }
    
    public async Task<BaseResponse<string>> AddClaimsUserAsync(int userId, List<string> claims)
    {
        var response = new BaseResponse<string>();
        
        var user = await _userManager.FindByIdAsync(userId.ToString());
            
        if (user == null)
        {
            response.IsError = true;
            response.Description = $"UserNotFound";
            return response;
        }

        var allClaims = _claimService.GetListClaims();
        var oldClaims = await _userManager.GetClaimsAsync(user);
        var listClaims = new List<Claim>();

        if (!claims.Except(allClaims.Data).Any())
        {
            var defClaim = claims.Except(oldClaims.Select(c => c.Type)).ToList();
                
            foreach (var claim in defClaim)
            {
                listClaims.Add(new Claim(claim, string.Empty));
            }
        }

        if (listClaims.Any())
        {
            await _userManager.AddClaimsAsync(user, listClaims);
        }
        else
        {
            response.IsError = true;
            response.Description = $"ClaimsNotExist";
            return response;
        }

        response.Data = "Успешно добавлен";
        return response;
    }
    
    public async Task<BaseResponse<string>> DeleteClaimUserAsync(int userId, string claimName)
    {
        var response = new BaseResponse<string>();
        
        // var user = await _userManager.FindByIdAsync(userId.ToString());
        //     
        // if (user == null)
        // {
        //     response.IsError = true;
        //     response.Description = $"UserNotFound";
        //     return response;
        // }
        //     
        // var claims = await _userManager.GetClaimsAsync(user);
        //     
        // if (!claims.Any())
        // {
        //     response.IsError = true;
        //     response.Description = $"UserClaimsNotFound";
        //     return response;
        // }
        //     
        // var selectClaim = claims.FirstOrDefault(c => c.Type.Contains(claimName));
        //
        // if (selectClaim == null)
        // {
        //     response.IsError = true;
        //     response.Description = $"UserDontHaveThisClaim";
        //     return response;
        // }
        //
        // // await _userClaimRepository.RemoveClaim(selectClaim.);
        //
        // // await _userClaimRepository.DeleteAsync(selectClaim);
        //
        // // await _userService.RemoveClaim(selectClaim.Id);
        // //
        // // var claim = await _context.UserClaims.FindAsync(id);
        // // _context.UserClaims.Remove(claim);
        // // await _context.SaveChangesAsync();

        response.Data = "Удалено успешно";
        return response;
    }
}