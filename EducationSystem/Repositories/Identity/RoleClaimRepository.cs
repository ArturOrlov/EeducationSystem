using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;

namespace EducationSystem.Repositories.Identity;

public class RoleClaimRepository :  GenericRepository<RoleClaim>, IRoleClaimRepository
{
    public RoleClaimRepository(EducationSystemDbContext context) : base(context)
    {
    }
}