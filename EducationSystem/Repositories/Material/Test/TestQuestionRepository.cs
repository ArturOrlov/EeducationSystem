using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.Test;
using EducationSystem.Interfaces.IRepositories.Material.Test;

namespace EducationSystem.Repositories.Material.Test;

public class TestQuestionRepository : GenericRepository<TestQuestion>, ITestQuestionRepository
{
    public TestQuestionRepository(EducationSystemDbContext context) : base(context)
    {
    }
}