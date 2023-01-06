using EducationSystem.Dto.Material.LaboratoryWork;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Material.LaboratoryWork;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IRepositories.Material.LaboratoryWork;
using EducationSystem.Interfaces.IServices.Material.LaboratoryWork;
using MapsterMapper;

namespace EducationSystem.Services.Material.LaboratoryWork;

public class UserLaboratoryWorkService : IUserLaboratoryWorkService
{
    private readonly IUserLaboratoryWorkRepository _userLaboratoryWorkRepository;
    private readonly ILaboratoryWorkRepository _laboratoryWorkRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserLaboratoryWorkService(IUserLaboratoryWorkRepository userLaboratoryWorkRepository,
        ILaboratoryWorkRepository laboratoryWorkRepository, 
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userLaboratoryWorkRepository = userLaboratoryWorkRepository;
        _laboratoryWorkRepository = laboratoryWorkRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetUserLaboratoryWorkDto>> GetUserLaboratoryWorkByIdAsync(int userLaboratoryWorkId)
    {
        var response = new BaseResponse<GetUserLaboratoryWorkDto>();

        var userLecture = await _userLaboratoryWorkRepository.GetByIdAsync(userLaboratoryWorkId);
        
        if (userLecture == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь-лабораторная работа с id - {userLaboratoryWorkId} не найден";
            return response;
        }

        var mapUserLecture = _mapper.Map<GetUserLaboratoryWorkDto>(userLecture);

        response.Data = mapUserLecture;
        return response;
    }

    public async Task<BaseResponse<List<GetUserLaboratoryWorkDto>>> GetUserLaboratoryWorkByPaginationAsync(BasePagination request)
    {
        var response = new BaseResponse<List<GetUserLaboratoryWorkDto>>();

        var userLectures = _userLaboratoryWorkRepository.Get(_ => true, request);

        if (!userLectures.Any())
        {
            return response;
        }

        var mapUserLectures = _mapper.Map<List<GetUserLaboratoryWorkDto>>(userLectures);

        response.Data = mapUserLectures;
        return response;
    }

    public async Task<BaseResponse<GetUserLaboratoryWorkDto>> CreateUserLaboratoryWorkAsync(CreateUserLaboratoryWorkDto request)
    {
        var response = new BaseResponse<GetUserLaboratoryWorkDto>();

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {request.UserId} не найден";
            return response;
        }
        
        var laboratoryWork = await _laboratoryWorkRepository.GetByIdAsync(request.LaboratoryWorkId);

        if (laboratoryWork == null)
        {
            response.IsError = true;
            response.Description = $"Лабораторная работа с id - {request.LaboratoryWorkId} не найдена";
            return response;
        }

        var newUserLecture = _mapper.Map<UserLaboratoryWork>(request);
        
        await _userLaboratoryWorkRepository.CreateAsync(newUserLecture);
        
        var mapUserLecture = _mapper.Map<GetUserLaboratoryWorkDto>(newUserLecture);
        
        response.Data = mapUserLecture;
        return response;
    }

    public async Task<BaseResponse<GetUserLaboratoryWorkDto>> UpdateUserLaboratoryWorkByIdAsync(int userLaboratoryWorkId, UpdateUserLaboratoryWorkDto request)
    {
        var response = new BaseResponse<GetUserLaboratoryWorkDto>();
        
        var userLecture = await _userLaboratoryWorkRepository.GetByIdAsync(userLaboratoryWorkId);

        if (userLecture == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь-лабораторная работа с id - {userLaboratoryWorkId} не найден";
            return response;
        }

        if (request.UserId != userLecture.UserId)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
            {
                response.IsError = true;
                response.Description = $"Пользователь с id - {request.UserId} не найден";
                return response;
            }
            
            userLecture.UserId = request.UserId;
        }

        if (request.LaboratoryWorkId != userLecture.LaboratoryWorkId)
        {
            var lecture = await _laboratoryWorkRepository.GetByIdAsync(request.LaboratoryWorkId);

            if (lecture != null)
            {
                response.IsError = true;
                response.Description = $"Лекция с id - {request.UserId} не найден";
                return response;
            }
            
            userLecture.LaboratoryWorkId = request.LaboratoryWorkId;
        }

        if (request.Value != userLecture.Value)
        {
            userLecture.Value = request.Value;
        }

        userLecture.UpdatedAt = DateTime.Now;
        await _userLaboratoryWorkRepository.UpdateAsync(userLecture);
        
        var mapUserLecture = _mapper.Map<GetUserLaboratoryWorkDto>(userLecture);
        
        response.Data = mapUserLecture;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteUserLaboratoryWorkByIdAsync(int userLaboratoryWorkId)
    {
        var response = new BaseResponse<string>();

        var userLecture = await _userLaboratoryWorkRepository.GetByIdAsync(userLaboratoryWorkId);

        if (userLecture == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь-лабораторная работа с id - {userLaboratoryWorkId} не найден";
            return response;
        }

        await _userLaboratoryWorkRepository.DeleteAsync(userLecture);

        response.Data = "Удалено";
        return response;
    }
}