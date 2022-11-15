using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels;

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
    /// Статус доступа к курсу
    /// </summary>
    [Column("IsActive"), Comment("Статус доступа к курсу")]
    public bool IsActive { get; set; }
}