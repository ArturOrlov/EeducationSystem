using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.Test;
using EducationSystem.Interfaces.IRepositories.Material.Test;

namespace EducationSystem.Repositories.Material.Test;

public class TestAnswerRepository : GenericRepository<TestAnswer>, ITestAnswerRepository
{
    public TestAnswerRepository(EducationSystemDbContext context) : base(context)
    {
    }
}