﻿using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Material.Test;

/// <summary>
/// Тест - голова теста
/// </summary>
public class TestAnswer : BaseEntity<int>
{
    /// <summary>
    /// Уникальный идентификатор вопроса / к какому вопросу относится этот ответ
    /// </summary>
    [Column("CourseId"), Comment("Уникальный идентификатор курса")]
    public int TestQuestionId { get; set; }
    public TestQuestion TestQuestion { get; set; }
    
    /// <summary>
    /// Описание вопроса ответа
    /// </summary>
    [Column("QuestionAnswer"), Comment("Описание ответа теста")]
    public string QuestionAnswer { get; set; }
    
    /// <summary>
    /// Флаг. является ли ответ правильным
    /// </summary>
    [Column("IsCorrect"), Comment("Флаг. является ли ответ правильным")]
    public bool IsCorrect { get; set; }
}