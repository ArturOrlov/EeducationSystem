using EducationSystem.Dto.UserInfo;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IServices;
using MapsterMapper;

namespace EducationSystem.Services;

public class UserInfoService : IUserInfoService
{
    private readonly IUserInfoRepository _userInfoRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserInfoService(IUserInfoRepository userInfoRepository,
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userInfoRepository = userInfoRepository;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<BaseResponse<GetUserInfoDto>> GetByIdAsync(int userId)
    {
        var response = new BaseResponse<GetUserInfoDto>();

        var userInfo = _userInfoRepository.Get(ui => ui.UserId == userId).FirstOrDefault();

        if (userInfo == null)
        {
            response.IsError = true;
            response.Description = "Неверный логин или пароль";
            return response;
        }

        var mapUserInfo = _mapper.Map<GetUserInfoDto>(userInfo);

        response.Data = mapUserInfo;
        return response;
    }

    public async Task<BaseResponse<GetUserInfoDto>> CreateAsync(int userId, CreateUserInfoDto request)
    {
        var response = new BaseResponse<GetUserInfoDto>();

        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            response.IsError = true;
            response.Description = "Неверный логин или пароль";
            return response;
        }

        var userInfo = _mapper.Map<UserInfo>(request);

        await _userInfoRepository.CreateAsync(userInfo);

        var mapUserInfo = _mapper.Map<GetUserInfoDto>(userInfo);

        response.Data = mapUserInfo;
        return response;
    }

    public async Task<BaseResponse<GetUserInfoDto>> UpdateByIdAsync(int userId, UpdateUserInfoDto request)
    {
        var response = new BaseResponse<GetUserInfoDto>();

        var user = await _userRepository.GetByIdAsync(userId);

        if (user == null)
        {
            response.IsError = true;
            response.Description = "Неверный логин или пароль";
            return response;
        }
        
        var userInfo = _userInfoRepository.Get(ui => ui.UserId == userId).FirstOrDefault();

        if (userInfo == null)
        {
            var createUserInfo = _mapper.Map<CreateUserInfoDto>(request);
            var result = await CreateAsync(userId, createUserInfo);
            
            response.Data = result.Data;
            return response;
        }

        userInfo.UpdatedAt = DateTime.Now;
        await _userInfoRepository.UpdateAsync(userInfo);

        var mapUserInfo = _mapper.Map<GetUserInfoDto>(userInfo);

        response.Data = mapUserInfo;
        return response;
    }
}