using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Identity;

public interface IUserClaimService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<BaseResponse<List<string>>> GetListClaimByUserIdAsync(int userId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="claims"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> AddClaimsUserAsync(int userId, List<string> claims);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="claimName"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteClaimUserAsync(int userId, string claimName);
}