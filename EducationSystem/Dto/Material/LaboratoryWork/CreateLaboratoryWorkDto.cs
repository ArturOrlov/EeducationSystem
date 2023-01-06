namespace EducationSystem.Dto.Material.LaboratoryWork;

public class CreateLaboratoryWorkDto
{
    public string Name { get; set; }
    public int CourseId { get; set; }
    public IFormFile? Material { get; set; }
    public bool IsActive { get; set; }
}