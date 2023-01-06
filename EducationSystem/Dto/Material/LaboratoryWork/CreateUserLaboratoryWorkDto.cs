namespace EducationSystem.Dto.Material.LaboratoryWork;

public class CreateUserLaboratoryWorkDto
{
    public int UserId { get; set; }
    public int LaboratoryWorkId { get; set; }
    public float? Value { get; set; }
}