using System.Security.Claims;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IServices.Identity;
using Microsoft.AspNetCore.Identity;

namespace EducationSystem.Services.Identity;

public class RoleClaimService : IRoleClaimService
{
    private readonly RoleManager<Role> _roleManager;
    private readonly IClaimService _claimService;

    public RoleClaimService(RoleManager<Role> roleManager,
        IClaimService claimService)
    {
        _roleManager = roleManager;
        _claimService = claimService;
    }

    public async Task<BaseResponse<List<Claim>>> GetListClaimByRoleIdAsync(int roleId)
    {
        var response = new BaseResponse<List<Claim>>();
        
        var role = await _roleManager.FindByIdAsync(roleId.ToString());
        
        if (role == null)
        {
            response.IsError = true;
            response.Description = $"Роль с id - {roleId} не найден";
            return response;
        }
        
        var listClaims = await _roleManager.GetClaimsAsync(role);
        
        if (!listClaims.Any())
        {
            response.IsError = true;
            response.Description = "claims не найдены";
            return response;
        }
        
        response.Data = listClaims.ToList();
        return response;
    }

    public async Task<BaseResponse<string>> AddClaimsRoleAsync(int roleId, List<string> claims)
    {
        var response = new BaseResponse<string>();

        var role = await _roleManager.FindByIdAsync(roleId.ToString());

        if (role == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {roleId} не найден";
            return response;
        }

        var allClaims = _claimService.GetListClaims();
        var oldClaims = await _roleManager.GetClaimsAsync(role);
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
            foreach (var cl in listClaims)
            {
                _roleManager.AddClaimAsync(role, cl).GetAwaiter().GetResult();
            }
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

    public async Task<BaseResponse<string>> DeleteClaimRoleAsync(int roleId, string claimName)
    {
        var response = new BaseResponse<string>();

        var role = await _roleManager.FindByIdAsync(roleId.ToString());

        if (role == null)
        {
            response.IsError = true;
            response.Description = $"RoleNotFound";
            return response;
        }

        var claims = await _roleManager.GetClaimsAsync(role);

        if (claims == null)
        {
            response.IsError = true;
            response.Description = $"UserClaimsNotFound";
            return response;
        }

        var selectClaim = claims.FirstOrDefault(c => c.Type.Contains(claimName));

        if (selectClaim == null)
        {
            response.IsError = true;
            response.Description = $"UserDontHaveThisClaim";
            return response;
        }

        await _roleManager.RemoveClaimAsync(role, selectClaim);

        response.Data = "Удалено успешно";
        return response;
    }
}