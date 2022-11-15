using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.Test;
using EducationSystem.Interfaces.IRepositories.Material.Test;

namespace EducationSystem.Repositories.Material.Test;

public class UserTestQuestionRepository : GenericRepository<UserTestQuestion>, IUserTestQuestionRepository
{
    public UserTestQuestionRepository(EducationSystemDbContext context) : base(context)
    {
    }
}