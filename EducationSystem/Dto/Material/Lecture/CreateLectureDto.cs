namespace EducationSystem.Dto.Material.Lecture;

public class CreateLectureDto
{
    public string Name { get; set; }
    public int CourseId { get; set; }
    public IFormFile? Material { get; set; }
    public bool IsActive { get; set; }
}