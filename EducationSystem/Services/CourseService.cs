using EducationSystem.Dto.Course;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels;
using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IServices;
using MapsterMapper;

namespace EducationSystem.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository,
        IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<BaseResponse<GetCourseDto>> GetCourseByIdAsync(int courseId)
    {
        var response = new BaseResponse<GetCourseDto>();

        var course = await _courseRepository.GetByIdAsync(courseId);
        
        if (course == null)
        {
            response.IsError = true;
            response.Description = $"Курс с id - {courseId} не найден";
            return response;
        }

        var mapCourse = _mapper.Map<GetCourseDto>(course);

        response.Data = mapCourse;
        return response;
    }

    public async Task<BaseResponse<List<GetCourseDto>>> GetCourseByPaginationAsync(BasePagination request)
    {
        var response = new BaseResponse<List<GetCourseDto>>();

        var courses = _courseRepository.Get(_ => true, request);

        if (!courses.Any())
        {
            return response;
        }

        var mapCourses = _mapper.Map<List<GetCourseDto>>(courses);

        response.Data = mapCourses;
        return response;
    }

    public async Task<BaseResponse<GetCourseDto>> CreateCourseAsync(CreateCourseDto request)
    {
        var response = new BaseResponse<GetCourseDto>();

        if (string.IsNullOrEmpty(request.Name))
        {
            response.IsError = true;
            response.Description = "Название курса отсутствует";
            return response;
        }

        var course = _courseRepository.Get(s => s.Name == request.Name).FirstOrDefault();

        if (course != null)
        {
            response.IsError = true;
            response.Description = "Курс с таким названием уже есть";
            return response;
        }

        var newCourse = _mapper.Map<Course>(request);
        
        await _courseRepository.CreateAsync(newCourse);
        
        var mapSubject = _mapper.Map<GetCourseDto>(newCourse);
        
        response.Data = mapSubject;
        return response;
    }

    public async Task<BaseResponse<GetCourseDto>> UpdateCourseByIdAsync(int courseId, UpdateCourseDto request)
    {
        var response = new BaseResponse<GetCourseDto>();
        
        var course = await _courseRepository.GetByIdAsync(courseId);

        if (course == null)
        {
            response.IsError = true;
            response.Description = $"Курс с id - {courseId} не найден";
            return response;
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            var subjects = _courseRepository.Get(s => s.Name == request.Name).FirstOrDefault();

            if (subjects != null)
            {
                response.IsError = true;
                response.Description = "Курс с таким названием уже есть";
                return response;
            }

            course.Name = request.Name;
        }

        course.UpdatedAt = DateTime.Now;
        await _courseRepository.UpdateAsync(course);
        
        var mapSubject = _mapper.Map<GetCourseDto>(course);
        
        response.Data = mapSubject;
        return response;
    }

    public async Task<BaseResponse<string>> DeleteCourseByIdAsync(int courseId)
    {
        var response = new BaseResponse<string>();

        var course = await _courseRepository.GetByIdAsync(courseId);

        if (course == null)
        {
            response.IsError = true;
            response.Description = $"Курс с id - {courseId} не найден";
            return response;
        }

        await _courseRepository.DeleteAsync(course);

        response.Data = "Удалено";
        return response;
    }
}