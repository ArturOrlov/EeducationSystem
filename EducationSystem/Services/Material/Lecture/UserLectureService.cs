using EducationSystem.Dto.Material.Lecture;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Material.Lecture;
using EducationSystem.Interfaces.IRepositories.Identity;
using EducationSystem.Interfaces.IRepositories.Material.Lecture;
using EducationSystem.Interfaces.IServices.Material.Lecture;
using MapsterMapper;

namespace EducationSystem.Services.Material.Lecture;

public class UserLectureService : IUserLectureService
{
    private readonly IUserLectureRepository _userLectureRepository;
    private readonly ILectureRepository _lectureRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserLectureService(IUserLectureRepository userLectureRepository, 
        ILectureRepository lectureRepository, 
        IUserRepository userRepository,
        IMapper mapper)
    {
        _userLectureRepository = userLectureRepository;
        _lectureRepository = lectureRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetUserLectureDto>> GetUserLectureByIdAsync(int userLectureId)
    {
        var response = new BaseResponse<GetUserLectureDto>();

        var userLecture = await _userLectureRepository.GetByIdAsync(userLectureId);
        
        if (userLecture == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь-лекция с id - {userLectureId} не найден";
            return response;
        }

        var mapUserLecture = _mapper.Map<GetUserLectureDto>(userLecture);

        response.Data = mapUserLecture;
        return response;
    }

    public async Task<BaseResponse<List<GetUserLectureDto>>> GetUserLectureByPaginationAsync(BasePagination request)
    {
        var response = new BaseResponse<List<GetUserLectureDto>>();

        var userLectures = _userLectureRepository.Get(_ => true, request);

        if (!userLectures.Any())
        {
            return response;
        }

        var mapUserLectures = _mapper.Map<List<GetUserLectureDto>>(userLectures);

        response.Data = mapUserLectures;
        return response;
    }

    public async Task<BaseResponse<GetUserLectureDto>> CreateUserLectureAsync(CreateUserLectureDto request)
    {
        var response = new BaseResponse<GetUserLectureDto>();

        var user = await _userRepository.GetByIdAsync(request.UserId);

        if (user == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь с id - {request.UserId} не найден";
            return response;
        }
        
        var lecture = await _lectureRepository.GetByIdAsync(request.LectureId);

        if (lecture != null)
        {
            response.IsError = true;
            response.Description = $"Лекция с id - {request.UserId} не найден";
            return response;
        }

        var newUserLecture = _mapper.Map<UserLecture>(request);
        
        await _userLectureRepository.CreateAsync(newUserLecture);
        
        var mapUserLecture = _mapper.Map<GetUserLectureDto>(newUserLecture);
        
        response.Data = mapUserLecture;
        return response;
    }

    public async Task<BaseResponse<GetUserLectureDto>> UpdateUserLectureByIdAsync(int userLectureId, UpdateUserLectureDto request)
    {
        var response = new BaseResponse<GetUserLectureDto>();
        
        var userLecture = await _userLectureRepository.GetByIdAsync(userLectureId);

        if (userLecture == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь-лекция с id - {userLectureId} не найден";
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

        if (request.LectureId != userLecture.LectureId)
        {
            var lecture = await _lectureRepository.GetByIdAsync(request.LectureId);

            if (lecture != null)
            {
                response.IsError = true;
                response.Description = $"Лекция с id - {request.UserId} не найден";
                return response;
            }
            
            userLecture.LectureId = request.LectureId;
        }

        if (request.IsRead != userLecture.IsRead)
        {
            userLecture.IsRead = request.IsRead;
        }

        userLecture.UpdatedAt = DateTime.Now;
        await _userLectureRepository.UpdateAsync(userLecture);
        
        var mapUserLecture = _mapper.Map<GetUserLectureDto>(userLecture);
        
        response.Data = mapUserLecture;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteUserLectureByIdAsync(int userLectureId)
    {
        var response = new BaseResponse<string>();

        var userLecture = await _userLectureRepository.GetByIdAsync(userLectureId);

        if (userLecture == null)
        {
            response.IsError = true;
            response.Description = $"Пользователь-лекция с id - {userLectureId} не найден";
            return response;
        }

        await _userLectureRepository.DeleteAsync(userLecture);

        response.Data = "Удалено";
        return response;
    }
}