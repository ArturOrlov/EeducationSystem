using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.Base;

public abstract class BaseEntity<T>
{
    /// <summary>
    /// Дата создания сущности
    /// </summary>
    [Column("Id"), Comment("Уникальный идентификатор сущности")]
    public T Id { get; set; }
    
    /// <summary>
    /// Дата создания сущности
    /// </summary>
    [Column("CreatedAt"), Comment("Дата создания сущности")]
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// Дата последнего обновления сущности
    /// </summary>
    [Column("UpdatedAt"), Comment("Дата последнего обновления сущности")]
    public DateTime UpdatedAt { get; set; }
}

