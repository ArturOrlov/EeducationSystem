namespace EducationSystem.Dto.Material.Test;

public class GetTestDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CourseId { get; set; }
    public bool IsActive { get; set; }
    public int TimeForQuestion { get; set; }
}