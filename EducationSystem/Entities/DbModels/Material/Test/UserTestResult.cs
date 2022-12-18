using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using EducationSystem.Entities.DbModels.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Test;

public class UserTestResult : BaseEntity<int>
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    [Column("UserId"), Comment("todo")]
    public int UserId { get; set; }
    public User User { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор теста
    /// </summary>
    [Column("TestId"), Comment("Уникальный идентификатор теста")]
    public int TestId { get; set; }
    public Test Test { get; set; }
    
    /// <summary>
    /// Уникальный идентификатор ответа теста
    /// </summary>
    [Column("TestAnswerId"), Comment("Уникальный идентификатор ответа теста")]
    public int TestAnswerId { get; set; }
    public TestAnswer TestAnswer { get; set; }
}