using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Dictionaries;

/// <summary>
/// Настройки приложения
/// </summary>
public class ApplicationSettings : BaseEntity<int>
{
    public ApplicationSettings(string name, string alias, string value)
    {
        Name = name;
        Alias = alias;
        Value = value;
    }

    /// <summary>
    /// Имя (название) настройки
    /// </summary>
    [Column("Name"), Comment("Имя (название) настройки")]
    public string Name { get; set; }
    
    /// <summary>
    /// Описание
    /// </summary>
    [Column("Alias"), Comment("Описание")]
    public string Alias { get; set; }
    
    /// <summary>
    /// Значение настройки
    /// </summary>
    [Column("Value"), Comment("Значение настройки")]
    public string Value { get; set; }
}