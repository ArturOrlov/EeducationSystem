using EducationSystem.Entities.Base;

namespace EducationSystem.Interfaces.IServices.Identity;

public interface IClaimService
{
    BaseResponse<List<string>> GetListClaims();
}