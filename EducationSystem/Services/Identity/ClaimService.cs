using System.Reflection;
using EducationSystem.Entities.Base;
using EducationSystem.Enums.Claims;
using EducationSystem.Interfaces.IServices.Identity;

namespace EducationSystem.Services.Identity;

public class ClaimService : IClaimService
{
    public BaseResponse<List<string>> GetListClaims()
    {
        var response = new BaseResponse<List<string>>();
        
        var listClaims = typeof(Claims)
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.FieldType == typeof(string))
            .Select(x => (string)x.GetRawConstantValue())
            .ToList();

        if (!listClaims.Any())
        {
            response.IsError = true;
            response.Description = $"claims не найдены";
            return response;
        }

        response.Data = listClaims;
        return response;
    }
}