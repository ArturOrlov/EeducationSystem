using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Identity;

public class UserRole : IdentityUserRole<int>
{
    /// <summary>
    /// Дата создания сущности
    /// </summary>
    [Column("CreatedAt"), Comment("Дата создания сущности")]
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Дата последнего обновления сущности
    /// </summary>
    [Column("UpdatedAt"), Comment("Дата последнего обновления сущности")]
    public DateTime UpdatedAt { get; set; }
}