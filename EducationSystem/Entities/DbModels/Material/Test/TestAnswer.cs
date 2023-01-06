using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Test;

/// <summary>
/// Отеты для вопросов теста
/// </summary>
public class TestAnswer : BaseEntity<int>
{
    /// <summary>
    /// Уникальный идентификатор вопроса теста
    /// </summary>
    [Column("TestQuestionId"), Comment("Уникальный идентификатор вопроса теста")]
    public int TestQuestionId { get; set; }
    public TestQuestion TestQuestion { get; set; }
    
    /// <summary>
    /// Описание ответа
    /// </summary>
    [Column("QuestionAnswer"), Comment("Описание ответа")]
    public string QuestionAnswer { get; set; }
    
    /// <summary>
    /// Флаг. является ли ответ правильным
    /// </summary>
    [Column("IsCorrect"), Comment("Флаг. является ли ответ правильным")]
    public bool IsCorrect { get; set; }
}