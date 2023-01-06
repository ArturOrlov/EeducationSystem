using EducationSystem.Dto.Material.Lecture;
using EducationSystem.Entities.Base;
using EducationSystem.Enums;
using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IRepositories.Material.Lecture;
using EducationSystem.Interfaces.IServices;
using EducationSystem.Interfaces.IServices.Material.Lecture;
using MapsterMapper;

namespace EducationSystem.Services.Material.Lecture;

public class LectureService : ILectureService
{
    private readonly ILectureRepository _lectureRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;

    public LectureService(ILectureRepository lectureRepository,
        ICourseRepository courseRepository,
        IFileService fileService, 
        IMapper mapper)
    {
        _lectureRepository = lectureRepository;
        _courseRepository = courseRepository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetLectureDto>> GetLectureByIdAsync(int lectureId)
    {
        var response = new BaseResponse<GetLectureDto>();

        var userLecture = await _lectureRepository.GetByIdAsync(lectureId);
        
        if (userLecture == null)
        {
            response.IsError = true;
            response.Description = $"Лекция с id - {lectureId} не найден";
            return response;
        }

        var mapLecture = _mapper.Map<GetLectureDto>(userLecture);

        response.Data = mapLecture;
        return response;
    }

    public async Task<BaseResponse<List<GetLectureDto>>> GetLectureByPaginationAsync(BasePagination request)
    {
        var response = new BaseResponse<List<GetLectureDto>>();

        var lectures = _lectureRepository.Get(_ => true, request);

        if (!lectures.Any())
        {
            return response;
        }

        var mapLectures = _mapper.Map<List<GetLectureDto>>(lectures);

        response.Data = mapLectures;
        return response;
    }

    public async Task<BaseResponse<GetLectureDto>> CreateLectureAsync(CreateLectureDto request)
    {
        var response = new BaseResponse<GetLectureDto>();

        var checkName = _lectureRepository.Get(l => l.Name == request.Name).FirstOrDefault();

        if (checkName != null)
        {
            response.IsError = true;
            response.Description = $"Лекция с именем - '{request.Name}' уже есть";
            return response;
        }

        var course = await _courseRepository.GetByIdAsync(request.CourseId);

        if (course == null)
        {
            response.IsError = true;
            response.Description = $"Курс с id - {request.CourseId} не найден";
            return response;
        }
        
        var newLecture = _mapper.Map<Entities.DbModels.Material.Lecture.Lecture>(request);
        
        if (request.Material != null)
        {
            var filePath = await _fileService.SaveFile(request.Material, AppFileType.Material);
            newLecture.MaterialUrl = filePath;
        }
        else
        {
            newLecture.MaterialUrl = string.Empty;
        }
        
        await _lectureRepository.CreateAsync(newLecture);
        
        var mapTest = _mapper.Map<GetLectureDto>(newLecture);
        
        response.Data = mapTest;
        return response;
    }

    public async Task<BaseResponse<GetLectureDto>> UpdateLectureByIdAsync(int lectureId, UpdateLectureDto request)
    {
        var response = new BaseResponse<GetLectureDto>();
        
        var lecture = await _lectureRepository.GetByIdAsync(lectureId);

        if (lecture == null)
        {
            response.IsError = true;
            response.Description = $"Лекция с id - {lectureId} не найден";
            return response;
        }

        if (!string.IsNullOrEmpty(request.Name) && request.Name != lecture.Name)
        {
            var checkName = _lectureRepository.Get(l => l.Name == request.Name).FirstOrDefault();;

            if (checkName != null)
            {
                response.IsError = true;
                response.Description = $"Лекция с именем - '{request.Name}' уже есть";
                return response;
            }
        }

        if (request.CourseId != lecture.CourseId)
        {
            var course = await _courseRepository.GetByIdAsync(request.CourseId);

            if (course == null)
            {
                response.IsError = true;
                response.Description = $"Курс с id - {request.CourseId} не найден";
                return response;
            }
            
            lecture.CourseId = request.CourseId;
        }

        if (request.Material != null)
        {
            _fileService.DeleteFile(lecture.MaterialUrl);
            var filePath = await _fileService.SaveFile(request.Material, AppFileType.Image);
            lecture.MaterialUrl = filePath;
        }

        if (request.IsActive != lecture.IsActive)
        {
            lecture.IsActive = request.IsActive;
        }

        lecture.UpdatedAt = DateTime.Now;
        await _lectureRepository.UpdateAsync(lecture);
        
        var mapLecture = _mapper.Map<GetLectureDto>(lecture);
        
        response.Data = mapLecture;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteLectureByIdAsync(int lectureId)
    {
        var response = new BaseResponse<string>();

        var lecture = await _lectureRepository.GetByIdAsync(lectureId);

        if (lecture == null)
        {
            response.IsError = true;
            response.Description = $"Лекция с id - {lectureId} не найден";
            return response;
        }
        
        if (!string.IsNullOrEmpty(lecture.MaterialUrl))
        {
            _fileService.DeleteFile(lecture.MaterialUrl);
        }

        await _lectureRepository.DeleteAsync(lecture);

        response.Data = "Удалено";
        return response;
    }
}