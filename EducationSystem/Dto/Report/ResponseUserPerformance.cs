using EducationSystem.Dto.Course;
using EducationSystem.Dto.Identity.User;

namespace EducationSystem.Dto.Report;

public class ResponseUserPerformance
{
    public UserFio User { get; set; }
    public GetCourseDto Course { get; set; }
    public List<UserPerformanceData> LaboratoryWorks { get; set; }
    public List<UserPerformanceData> Tests { get; set; }
}