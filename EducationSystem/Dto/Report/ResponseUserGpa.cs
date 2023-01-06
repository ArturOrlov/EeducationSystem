using EducationSystem.Dto.Course;
using EducationSystem.Dto.Identity.User;

namespace EducationSystem.Dto.Report;

public class ResponseUserGpa
{
    public UserFio User { get; set; }
    public GetCourseDto Course { get; set; }
    public float UserGpa { get; set; }
}