using EducationSystem.Context;
using EducationSystem.Entities.DbModels;
using EducationSystem.Entities.DbModels.Education;
using EducationSystem.Interfaces.IRepositories;

namespace EducationSystem.Repositories;

public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(EducationSystemDbContext context) : base(context)
    {
    }
}