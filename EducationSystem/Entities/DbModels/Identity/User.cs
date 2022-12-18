using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Identity;

/// <summary>
/// 
/// </summary>
public class User : IdentityUser<int>
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
    //
    // /// <summary>
    // /// Рефреш токен"
    // /// </summary>
    // [Column("RefreshToken"), Comment("Рефреш токен")]
    // public string? RefreshToken { get; set; }
    //
    // /// <summary>
    // /// Время истечения рефреш токена
    // /// </summary>
    // [Column("RefreshTokenExpiryTime"), Comment("Время истечения рефреш токена")]
    // public DateTime RefreshTokenExpiryTime { get; set; }
}