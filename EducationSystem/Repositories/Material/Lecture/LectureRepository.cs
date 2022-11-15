using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.Lecture;
using EducationSystem.Interfaces.IRepositories.Material.Lecture;

namespace EducationSystem.Repositories.Material.Lecture;

public class LectureRepository : GenericRepository<Entities.DbModels.Material.Lecture.Lecture>, ILectureRepository
{
    public LectureRepository(EducationSystemDbContext context) : base(context)
    {
    }
}