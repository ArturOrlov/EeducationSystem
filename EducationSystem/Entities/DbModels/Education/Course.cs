using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Education;

/// <summary>
/// Курс
/// </summary>
public class Course : BaseEntity<int>
{
    /// <summary>
    /// Название курса
    /// </summary>
    [Column("Name"), Comment("Название курса")]
    public string Name { get; set; }
    
    /// <summary>
    /// Название курса
    /// </summary>
    [Column("SubjectId"), Comment("Уникальный идентификатор предмета")]
    public int? SubjectId { get; set; }
    public Subject? Subject { get; set; }
    
    /// <summary>
    /// Статус доступа к курсу
    /// </summary>
    [Column("IsActive"), Comment("Статус доступа к курсу")]
    public bool IsActive { get; set; }
}