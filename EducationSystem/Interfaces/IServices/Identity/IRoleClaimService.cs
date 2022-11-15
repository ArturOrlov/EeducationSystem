using System.Security.Claims;
using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Identity;

public interface IRoleClaimService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <returns></returns>
    Task<BaseResponse<List<Claim>>> GetListClaimByRoleIdAsync(int roleId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="claims"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> AddClaimsRoleAsync(int roleId, List<string> claims);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="claimName"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteClaimRoleAsync(int roleId, string claimName);
}