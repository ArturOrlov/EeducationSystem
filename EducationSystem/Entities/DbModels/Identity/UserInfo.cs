using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Identity;

public class UserInfo : BaseEntity<int>
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    [Column("UserId"), Comment("Уникальный идентификатор пользователя")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    /// <summary>
    /// Имя пользователя
    /// </summary>
    [Column("FirstName"), Comment("Имя пользователя")]
    public string FirstName { get; set; }
    
    /// <summary>
    /// Фамилия пользователя
    /// </summary>
    [Column("LastName"), Comment("Фамилия пользователя")]
    public string LastName { get; set; }
    
    /// <summary>
    /// Отчесвто пользователя
    /// </summary>
    [Column("Patronymic"), Comment("Отчесвто пользователя")]
    public string Patronymic { get; set; }
    
    /// <summary>
    /// Дата рождения пользователя
    /// </summary>
    [Column("Birthday"), Comment("Дата рождения пользователя")]
    public DateTime? Birthday { get; set; }
}
