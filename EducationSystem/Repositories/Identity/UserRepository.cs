using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;

namespace EducationSystem.Repositories.Identity;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(EducationSystemDbContext context) : base(context)
    {
    }
}