using EducationSystem.Context;
using EducationSystem.Interfaces.IRepositories.Material.Test;

namespace EducationSystem.Repositories.Material.Test;

public class TestRepository : GenericRepository<Entities.DbModels.Material.Test.Test>, ITestRepository
{
    public TestRepository(EducationSystemDbContext context) : base(context)
    {
    }
}