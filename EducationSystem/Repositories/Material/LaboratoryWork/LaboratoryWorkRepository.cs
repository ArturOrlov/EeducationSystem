using EducationSystem.Context;
using EducationSystem.Interfaces.IRepositories.Material.LaboratoryWork;

namespace EducationSystem.Repositories.Material.LaboratoryWork;

public class LaboratoryWorkRepository : GenericRepository<Entities.DbModels.Material.LaboratoryWork.LaboratoryWork>, ILaboratoryWorkRepository
{
    public LaboratoryWorkRepository(EducationSystemDbContext context) : base(context)
    {
    }
}