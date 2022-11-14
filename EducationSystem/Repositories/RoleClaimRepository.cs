using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories;

namespace EducationSystem.Repositories;

public class RoleClaimRepository :  GenericRepository<RoleClaim>, IRoleClaimRepository
{
    public RoleClaimRepository(EducationSystemDbContext context) : base(context)
    {
    }
}