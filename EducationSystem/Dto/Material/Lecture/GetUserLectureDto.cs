namespace EducationSystem.Dto.Material.Lecture;

public class GetUserLectureDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int LectureId { get; set; }
    public bool IsRead { get; set; }
}