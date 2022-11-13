using EducationSystem.Entities.DbModels.Dictionaries;

namespace EducationSystem.Interfaces.IRepositories;

public interface IApplicationSettingsRepository : IGenericRepository<ApplicationSettings>
{
    Task<ApplicationSettings> GetByNameAsync(string name);
    Task<List<ApplicationSettings>> GetAllSettingsAsync();
}