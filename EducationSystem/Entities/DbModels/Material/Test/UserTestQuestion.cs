using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Test;

/// <summary>
/// 
/// </summary>
public class UserTestQuestion : BaseEntity<int>
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    [Column("UserId"), Comment("Уникальный идентификатор пользователя")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Column("UserId"), Comment("Уникальный идентификатор курса")]
    public int TestQuestionId { get; set; }
    public TestQuestion TestQuestion { get; set; }
    
    /// <summary>
    /// Оценка
    /// </summary>
    [Column("Value"), Comment("Оценка пользователя по курсу")]
    public int? Value { get; set; }
}