using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Test;

public class UserTestAnswer : BaseEntity<int>
{
    /// <summary>
    /// 
    /// </summary>
    [Column("UserTestBodyQuestionId"), Comment("Уникальный идентификатор курса")]
    public int UserTestQuestionId { get; set; }
    public UserTestQuestion UserTestQuestion { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    [Column("TestBodyAnswerId"), Comment("Уникальный идентификатор курса")]
    public int TestAnswerId { get; set; }
    public TestAnswer TestAnswer { get; set; }
}