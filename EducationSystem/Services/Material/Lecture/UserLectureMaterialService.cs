using EducationSystem.Dto.Lecture;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories.Material.Lecture;
using EducationSystem.Interfaces.IServices.Material.Lecture;

namespace EducationSystem.Services.Material.Lecture;

public class UserLectureMaterial : IUserLectureService
{
    private readonly IUserLectureRepository _userLectureRepository;

    public UserLectureMaterial(IUserLectureRepository userLectureRepository)
    {
        _userLectureRepository = userLectureRepository;
    }

    public async Task<BaseResponse<GetUserLectureDto>> GetUserLectureByIdAsync(int userLectureId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<GetUserLectureDto>>> GetUserLectureByPaginationAsync(BasePagination request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetUserLectureDto>> CreateUserLectureAsync(CreateUserLectureDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetUserLectureDto>> UpdateUserLectureByIdAsync(int userLectureId, UpdateUserLectureDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<string>> DeleteUserLectureByIdAsync(int userLectureId)
    {
        throw new NotImplementedException();
    }
}