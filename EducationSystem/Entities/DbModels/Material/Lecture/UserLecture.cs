using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.DbModels.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Lecture;

public class UserLecture
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
    [Column("CourseId"), Comment("Уникальный идентификатор леции")]
    public int LectureMaterialId { get; set; }
    public Lecture Lecture { get; set; }
    
    /// <summary>
    /// Статус доступа к курсу
    /// </summary>
    [Column("IsRead"), Comment("Статус доступа к курсу")]
    public bool IsRead { get; set; }
}