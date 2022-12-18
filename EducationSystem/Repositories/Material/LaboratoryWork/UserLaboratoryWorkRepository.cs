using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.Lecture;
using EducationSystem.Interfaces.IRepositories.Material.LaboratoryWork;

namespace EducationSystem.Repositories.Material.LaboratoryWork;

public class UserLaboratoryWorkRepository : GenericRepository<UserLecture>, IUserLaboratoryWorkRepository
{
    public UserLaboratoryWorkRepository(EducationSystemDbContext context) : base(context)
    {
    }
}