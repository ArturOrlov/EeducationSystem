using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.Test;
using EducationSystem.Interfaces.IRepositories.Material.Test;

namespace EducationSystem.Repositories.Material.Test;

public class UserTestAnswerRepository : GenericRepository<UserTestAnswer>, IUserTestAnswerRepository
{
    public UserTestAnswerRepository(EducationSystemDbContext context) : base(context)
    {
    }
}