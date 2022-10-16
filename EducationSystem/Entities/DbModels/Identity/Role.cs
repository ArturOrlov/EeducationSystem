using Microsoft.AspNetCore.Identity;

namespace EducationSystem.Entities.DbModels.Identity;

public class Role : IdentityRole<int>
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}