using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices;

public interface IClaimService
{
    BaseResponse<List<string>> GetListClaims();
}