using Microsoft.AspNetCore.Identity;

namespace EducationSystem.Entities.DbModels.Identity
{
    public class UserRole : IdentityUserRole<int>
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}