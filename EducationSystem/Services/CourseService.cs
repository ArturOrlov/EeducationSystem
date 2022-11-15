using EducationSystem.Dto.Course;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories;
using EducationSystem.Interfaces.IServices;

namespace EducationSystem.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<BaseResponse<GetCourseDto>> GetCourseByIdAsync(int courseId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<GetCourseDto>>> GetCourseByPaginationAsync(BasePagination request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetCourseDto>> CreateCourseAsync(CreateCourseDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetCourseDto>> UpdateCourseByIdAsync(int courseId, UpdateCourseDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<string>> DeleteCourseByIdAsync(int courseId)
    {
        throw new NotImplementedException();
    }
}