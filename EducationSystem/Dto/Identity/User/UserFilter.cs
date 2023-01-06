using EducationSystem.Entities.Base;

namespace EducationSystem.Dto.Identity.User;

public class UserFilter : BasePagination
{
    public int RoleId { get; set; }
}