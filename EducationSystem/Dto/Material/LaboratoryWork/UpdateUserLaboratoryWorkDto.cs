namespace EducationSystem.Dto.Material.LaboratoryWork;

public class UpdateUserLaboratoryWorkDto
{
    public int UserId { get; set; }
    public int LaboratoryWorkId { get; set; }
    public float? Value { get; set; }
}