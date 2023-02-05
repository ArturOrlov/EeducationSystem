using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Education;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Lecture;

/// <summary>
/// Материал - Лекция
/// </summary>
public class Lecture : BaseEntity<int>
{
    /// <summary>
    /// Название лекции
    /// </summary>
    [Column("Name"), Comment("Название лекции")]
    public string Name { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор курса
    /// </summary>
    [Column("CourseId"), Comment("Уникальный идентификатор курса")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    /// <summary>
    /// Ссылка на материал лекции
    /// </summary>
    [Column("MaterialUrl"), Comment("Ссылка на материал лекции")]
    public string MaterialUrl { get; set; }
    
    /// <summary>
    /// Статус доступа к курсу
    /// </summary>
    [Column("IsActive"), Comment("Статус доступа к курсу")]
    public bool IsActive { get; set; }
}