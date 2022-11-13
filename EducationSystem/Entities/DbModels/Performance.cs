using EducationSystem.Entities.Base;

namespace EducationSystem.Entities.DbModels;

/// <summary>
/// Успеваемость
/// </summary>
public class Performance : BaseEntity<int>
{
    // /// <summary>
    // /// Уникальный идентификатор пользователя
    // /// </summary>
    // [Column("UserId"), Comment("Уникальный идентификатор пользователя")]
    // public int UserId { get; set; }
    // public User User { get; set; }
    //
    // /// <summary>
    // /// Уникальный идентификатор курса
    // /// </summary>
    // [Column("CourseId"), Comment("Уникальный идентификатор курса")]
    // public int CourseId { get; set; }
    // public Course Course { get; set; }
    //
    // /// <summary>
    // /// Оценка
    // /// </summary>
    // [Column("Value"), Comment("Оценка пользователя по курсу")]
    // public int? Value { get; set; }
}