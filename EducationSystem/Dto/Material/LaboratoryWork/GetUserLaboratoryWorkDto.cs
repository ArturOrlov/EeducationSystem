namespace EducationSystem.Dto.Material.LaboratoryWork;

public class GetUserLaboratoryWorkDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int LaboratoryWorkId { get; set; }
    public float? Value { get; set; }
}