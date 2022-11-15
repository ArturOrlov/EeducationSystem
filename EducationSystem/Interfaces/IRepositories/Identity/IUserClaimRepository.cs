using EducationSystem.Entities.DbModels.Identity;

namespace EducationSystem.Interfaces.IRepositories.Identity;

public interface IUserClaimRepository : IGenericRepository<UserClaim>
{
    Task RemoveClaim(int id);
}