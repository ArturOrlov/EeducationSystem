using EducationSystem.Entities.Base;

namespace EducationSystem.Dto.User;

public class UserFilter : BasePagination
{
    public int RoleId { get; set; }
}