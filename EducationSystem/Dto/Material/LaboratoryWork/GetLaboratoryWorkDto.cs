namespace EducationSystem.Dto.Material.LaboratoryWork;

public class GetLaboratoryWorkDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CourseId { get; set; }
    public string MaterialUrl { get; set; }
    public bool IsActive { get; set; }
}