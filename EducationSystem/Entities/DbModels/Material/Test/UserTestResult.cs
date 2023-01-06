using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Test;

/// <summary>
/// Результат прохождения теста пользователя
/// </summary>
public class UserTestResult : BaseEntity<int>
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    [Column("UserId"), Comment("Уникальный идентификатор пользовтеля")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор теста
    /// </summary>
    [Column("TestId"), Comment("Уникальный идентификатор теста")]
    public int TestId { get; set; }
    public Test Test { get; set; }
    
    /// <summary>
    /// Оценка по количеству правильных ответов
    /// </summary>
    [Column("Value"), Comment("Оценка по количеству правильных ответов")]
    public float Value { get; set; }
}