using EducationSystem.Dto.Material;

namespace EducationSystem.Dto.Course;

public class CourseWithMaterialsDto
{
    public GetCourseDto Course { get; set; }
    public MaterialsDto Materials { get; set; }
}