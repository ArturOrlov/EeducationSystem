using EducationSystem.Context;
using EducationSystem.Interfaces.IRepositories.Material.LaboratoryWork;

namespace EducationSystem.Repositories.Material.LaboratoryWork;

public class LaboratoryWorkRepository : GenericRepository<Entities.DbModels.Material.Lecture.Lecture>, ILaboratoryWorkRepository
{
    public LaboratoryWorkRepository(EducationSystemDbContext context) : base(context)
    {
    }
}