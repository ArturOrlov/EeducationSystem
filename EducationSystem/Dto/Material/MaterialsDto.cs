using EducationSystem.Dto.Material.LaboratoryWork;
using EducationSystem.Dto.Material.Lecture;
using EducationSystem.Dto.Material.Test;

namespace EducationSystem.Dto.Material;

public class MaterialsDto
{
    public List<GetLectureDto> Lectures { get; set; }
    public List<GetLaboratoryWorkDto> LaboratoryWorks { get; set; }
    public List<GetTestDto> Tests { get; set; }
}