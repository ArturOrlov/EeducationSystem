using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.LaboratoryWork;

/// <summary>
/// 
/// </summary>
public class UserLaboratoryWork : BaseEntity<int>
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    [Column("UserId"), Comment("Уникальный идентификатор пользователя")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор леции
    /// </summary>
    [Column("LaboratoryWorkId"), Comment("Уникальный идентификатор леции")]
    public int LaboratoryWorkId { get; set; }
    public LaboratoryWork LaboratoryWork { get; set; }
    
    /// <summary>
    /// Оценка
    /// </summary>
    [Column("Value"), Comment("todo")]
    public int? Value { get; set; }
}