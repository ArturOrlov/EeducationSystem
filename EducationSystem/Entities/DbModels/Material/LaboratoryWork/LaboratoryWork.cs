using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.LaboratoryWork;

/// <summary>
/// Материал - Лабораторная работа
/// </summary>
public class LaboratoryWork : BaseEntity<int>
{
    /// <summary>
    /// Название лабораторной работы
    /// </summary>
    [Column("Name"), Comment("Название лабораторной работы")]
    public string Name { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор курса
    /// </summary>
    [Column("CourseId"), Comment("Уникальный идентификатор курса")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    /// <summary>
    /// Ссылка на материал лабораторной работы
    /// </summary>
    [Column("MaterialUrl"), Comment("Ссылка на материал лабораторной работы")]
    public string MaterialUrl { get; set; }
    
    /// <summary>
    /// Статус доступа к курсу
    /// </summary>
    [Column("IsActive"), Comment("Статус доступа к курсу")]
    public bool IsActive { get; set; }
}