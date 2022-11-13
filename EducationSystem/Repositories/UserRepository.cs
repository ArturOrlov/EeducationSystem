using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories;

namespace EducationSystem.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(EducationSystemDbContext context) : base(context)
    {
    }
}