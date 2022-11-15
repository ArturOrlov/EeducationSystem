using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Lecture;

public class Lecture
{
    /// <summary>
    /// Уникальный идентификатор курса
    /// </summary>
    [Column("CourseId"), Comment("Уникальный идентификатор курса")]
    public int CourseId { get; set; }
    public Course Course { get; set; }
    
    /// <summary>
    /// TODO
    /// </summary>
    [Column("Material"), Comment("TODO")]
    public string Material { get; set; }
    
    /// <summary>
    /// Статус доступа к курсу
    /// </summary>
    [Column("IsActive"), Comment("Статус доступа к курсу")]
    public bool IsActive { get; set; }
}