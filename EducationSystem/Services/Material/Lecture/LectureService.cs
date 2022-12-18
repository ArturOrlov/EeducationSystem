using EducationSystem.Dto.Lecture;
using EducationSystem.Entities.Base;
using EducationSystem.Interfaces.IRepositories.Material.Lecture;
using EducationSystem.Interfaces.IServices.Material.Lecture;

namespace EducationSystem.Services.Material.Lecture;

public class LectureService : ILectureService
{
    private readonly ILectureRepository _lectureRepository;

    public LectureService(ILectureRepository lectureRepository)
    {
        _lectureRepository = lectureRepository;
    }

    public async Task<BaseResponse<GetLectureDto>> GetLectureByIdAsync(int lectureId)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<List<GetLectureDto>>> GetLectureByPaginationAsync(BasePagination request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetLectureDto>> CreateLectureAsync(CreateLectureDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<GetLectureDto>> UpdateLectureByIdAsync(int lectureId, UpdateLectureDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<BaseResponse<string>> DeleteLectureByIdAsync(int lectureId)
    {
        throw new NotImplementedException();
    }
}