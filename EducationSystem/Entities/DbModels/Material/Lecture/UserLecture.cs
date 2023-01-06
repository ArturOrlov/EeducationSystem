using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Lecture;

/// <summary>
/// Результат прохождения лекции пользователя
/// </summary>
public class UserLecture : BaseEntity<int>
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
    [Column("LectureId"), Comment("Уникальный идентификатор леции")]
    public int LectureId { get; set; }
    public Lecture Lecture { get; set; }
    
    /// <summary>
    /// Статус прохождения лекции
    /// </summary>
    [Column("IsRead"), Comment("Статус прохождения лекции")]
    public bool IsRead { get; set; }
}