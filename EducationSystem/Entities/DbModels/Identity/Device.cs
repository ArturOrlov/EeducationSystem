using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Identity;

/// <summary>
/// 
/// </summary>
public class Device : BaseEntity<int>
{
    /// <summary>
    /// Id пользователя
    /// </summary>
    [Column("UserId"), Comment("Id пользователя")]
    public int UserId { get; set; }

    /// <summary>
    /// Пользователь
    /// </summary>
    [Column("User"), Comment("Пользователь")]
    public User User { get; set; }
        
    /// <summary>
    /// Последние время входа в систему
    /// </summary>
    [Column("LastLoginTime"), Comment("Последние время входа в систему")]
    public DateTime LastLoginTime { get; set; }
        
    /// <summary>
    /// Устройство входа
    /// </summary>
    [Column("UserAgent"), Comment("Устройство входа")]
    public string UserAgent { get; set; }
    //
    // /// <summary>
    // /// Рефреш токен
    // /// </summary>
    // [Column("RefreshToken"), Comment("Рефреш токен")]
    // public RefreshToken RefreshToken { get; set; }
}