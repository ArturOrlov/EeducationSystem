using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Education;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Test;

/// <summary>
/// Материал - Тест
/// </summary>
public class Test : BaseEntity<int>
{
    /// <summary>
    /// Название теста
    /// </summary>
    [Column("Name"), Comment("Название теста")]
    public string Name { get; set; }
    
    /// <summary>
    /// Описание теста
    /// </summary>
    [Column("Description"), Comment("Описание теста")]
    public string Description { get; set; }
    
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
}