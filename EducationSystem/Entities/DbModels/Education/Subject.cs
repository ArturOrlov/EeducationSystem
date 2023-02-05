using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Education;

/// <summary>
/// Предмет
/// </summary>
public class Subject : BaseEntity<int>
{
    /// <summary>
    /// Название предмета
    /// </summary>
    [Column("Name"), Comment("Название предмета")]
    public string Name { get; set; }
}