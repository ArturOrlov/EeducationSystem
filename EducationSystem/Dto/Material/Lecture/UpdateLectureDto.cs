namespace EducationSystem.Dto.Material.Lecture;

public class UpdateLectureDto
{
    public string Name { get; set; }
    public int CourseId { get; set; }
    public IFormFile? Material { get; set; }
    public bool IsActive { get; set; }
}