using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.LaboratoryWork;
using EducationSystem.Interfaces.IRepositories.Material.LaboratoryWork;

namespace EducationSystem.Repositories.Material.LaboratoryWork;

public class UserLaboratoryWorkRepository : GenericRepository<UserLaboratoryWork>, IUserLaboratoryWorkRepository
{
    public UserLaboratoryWorkRepository(EducationSystemDbContext context) : base(context)
    {
    }
}