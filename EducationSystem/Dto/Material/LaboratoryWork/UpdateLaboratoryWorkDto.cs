namespace EducationSystem.Dto.Material.LaboratoryWork;

public class UpdateLaboratoryWorkDto
{
    public string Name { get; set; }
    public int CourseId { get; set; }
    public IFormFile? Material { get; set; }
    public bool IsActive { get; set; }
}