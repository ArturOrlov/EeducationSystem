using EducationSystem.Dto.User;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;

namespace EducationSystem.Interfaces.IServices;

public interface IUserService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="login"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<BaseResponse<User>> GetByLoginAsync(string login, string password);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserDto>> GetByIdAsync(int userId);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userName"></param>
    /// <returns></returns>
    Task<BaseResponse<User>> FindUser(string userName);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<List<GetUserDto>>> GetByPaginationAsync(UserFilter request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserDto>> CreateAsync(CreateUserDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<BaseResponse<GetUserDto>> UpdateByIdAsync(int userId, UpdateUserDto request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<BaseResponse<string>> DeleteByIdAsync(int userId);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="claim"></param>
    /// <returns></returns>
    Task<bool> AuthorizeClaimsAsync(User user, string claim);
}