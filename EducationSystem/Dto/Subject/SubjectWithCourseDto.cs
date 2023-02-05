using EducationSystem.Dto.Course;

namespace EducationSystem.Dto.Subject;

public class SubjectWithCourseDto
{
    public GetSubjectDto Subject { get; set; }
    public List<GetCourseDto> Courses { get; set; }
}