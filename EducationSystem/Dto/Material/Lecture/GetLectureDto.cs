namespace EducationSystem.Dto.Material.Lecture;

public class GetLectureDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CourseId { get; set; }
    public string MaterialUrl { get; set; }
    public bool IsActive { get; set; }
}