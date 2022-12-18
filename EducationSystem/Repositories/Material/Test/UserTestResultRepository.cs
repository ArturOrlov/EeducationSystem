using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.Test;
using EducationSystem.Interfaces.IRepositories.Material.Test;

namespace EducationSystem.Repositories.Material.Test;

public class UserTestResultRepository : GenericRepository<UserTestResult>, IUserTestResultRepository
{
    public UserTestResultRepository(EducationSystemDbContext context) : base(context)
    {
    }
}