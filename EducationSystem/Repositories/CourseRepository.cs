using EducationSystem.Context;
using EducationSystem.Entities.DbModels;
using EducationSystem.Entities.DbModels.Education;
using EducationSystem.Interfaces.IRepositories;

namespace EducationSystem.Repositories;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(EducationSystemDbContext context) : base(context)
    {
    }
}