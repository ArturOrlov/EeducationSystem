using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;

namespace EducationSystem.Repositories.Identity;

public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
{
    public UserRoleRepository(EducationSystemDbContext context) : base(context)
    {
    }
}