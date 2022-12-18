using System.ComponentModel.DataAnnotations.Schema;
using EducationSystem.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Entities.DbModels.Identity;

/// <summary>
/// 
/// </summary>
public class VerificationToken : BaseEntity<int>
{
    public VerificationToken(string token, string data)
    {
        Token = token;
        Data = data;
    }
        
    /// <summary>
    /// Токен
    /// </summary>
    [Column("Token"), Comment("Токен")]
    public string Token { get; set; }

    /// <summary>
    /// Id устройства"
    /// </summary>
    [Column("Data"), Comment("Id устройства")]
    public string Data { get; set; }
}