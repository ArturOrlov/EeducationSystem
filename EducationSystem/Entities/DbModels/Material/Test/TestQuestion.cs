using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Test;

/// <summary>
/// Тест - голова теста
/// </summary>
public class TestQuestion : BaseEntity<int>
{
    /// <summary>
    /// Уникальный идентификатор теста
    /// </summary>
    [Column("CourseId"), Comment("Уникальный идентификатор курса")]
    public int TestHeadId { get; set; }
    public TestHead TestHead { get; set; }
    
    /// <summary>
    /// Описание вопроса теста
    /// </summary>
    [Column("QuestionDescription"), Comment("Описание вопроса теста")]
    public string QuestionDescription { get; set; }
    
    /// <summary>
    /// Изображение для вопроса
    /// </summary>
    [Column("Image"), Comment("Изображение для вопроса")]
    public string Image { get; set; }
}