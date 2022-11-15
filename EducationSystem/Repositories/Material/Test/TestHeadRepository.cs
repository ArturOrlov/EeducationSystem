using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.Test;
using EducationSystem.Interfaces.IRepositories.Material.Test;

namespace EducationSystem.Repositories.Material.Test;

public class TestHeadRepository : GenericRepository<TestHead>, ITestHeadRepository
{
    public TestHeadRepository(EducationSystemDbContext context) : base(context)
    {
    }
}