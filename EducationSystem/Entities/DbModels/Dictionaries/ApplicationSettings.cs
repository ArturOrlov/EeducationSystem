using EducationSystem.Entities.Base;

namespace EducationSystem.Entities.DbModels.Dictionaries;

/// <summary>
/// 
/// </summary>
public class ApplicationSettings : BaseEntity<int>
{
    public ApplicationSettings(string name, string alias, string value)
    {
        Name = name;
        Alias = alias;
        Value = value;
    }

    public string Name { get; set; }
    public string Alias { get; set; }
    public string Value { get; set; }
}