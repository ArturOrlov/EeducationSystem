namespace EducationSystem.Dto.Material.Lecture;

public class CreateUserLectureDto
{
    public int UserId { get; set; }
    public int LectureId { get; set; }
    public bool IsRead { get; set; }
}