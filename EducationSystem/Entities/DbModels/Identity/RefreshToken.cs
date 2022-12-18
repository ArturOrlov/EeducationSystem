using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Identity;

/// <summary>
/// 
/// </summary>
public class RefreshToken : BaseEntity<int>
{
    /// <summary>
    /// Id устройства
    /// </summary>
    [Column("DeviceId"), Comment("Id устройства")]
    public int DeviceId { get; set; }
        
    /// <summary>
    /// Устройство с которого был выполнен вход"
    /// </summary>
    [Column("Device"), Comment("Устройство с которого был выполнен вход")]
    public Device Device { get; set; }
        
    /// <summary>
    /// Рефреш токен"
    /// </summary>
    [Column("Token"), Comment("Рефреш токен")]
    public string Token { get; set; }

    /// <summary>
    /// Время истечения рефреш токена
    /// </summary>
    [Column("ExpireTime"), Comment("Время истечения рефреш токена")]
    public DateTime ExpireTime { get; set; }
}