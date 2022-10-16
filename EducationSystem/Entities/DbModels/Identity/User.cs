using Microsoft.AspNetCore.Identity;

namespace EducationSystem.Entities.DbModels.Identity;

public class User : IdentityUser<int>
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}