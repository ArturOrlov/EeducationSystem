using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Material.Lecture;
using EducationSystem.Interfaces.IRepositories.Material.Lecture;

namespace EducationSystem.Repositories.Material.Lecture;

public class UserLectureRepository : GenericRepository<UserLecture>, IUserLectureRepository
{
    public UserLectureRepository(EducationSystemDbContext context) : base(context)
    {
    }
}