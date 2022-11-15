using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Test;

/// <summary>
/// Тест - голова теста
/// </summary>
public class TestHead : BaseEntity<int>
{
    /// <summary>
    /// Название теста
    /// </summary>
    [Column("Name"), Comment("Название теста")]
    public string Name { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор курса
    /// </summary>
    [Column("CourseId"), Comment("Уникальный идентификатор курса")]
    public int CourseId { get; set; }
    public Course Course { get; set; }

    /// <summary>
    /// Статус доступа к тесту
    /// </summary>
    [Column("IsActive"), Comment("Статус доступа к тесту")]
    public bool IsActive { get; set; }
    
    /// <summary>
    /// Время на один ответ
    /// </summary>
    [Column("TimeForQuestion"), Comment("Время на один ответ")]
    public TimeSpan TimeForQuestion { get; set; }
}