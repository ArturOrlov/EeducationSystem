using EducationSystem.Entities.DbModels.Dictionaries;

namespace EducationSystem.Interfaces.IRepositories.Identity;

public interface IApplicationSettingsRepository : IGenericRepository<ApplicationSettings>
{
    Task<ApplicationSettings> GetByNameAsync(string name);
    Task<List<ApplicationSettings>> GetAllSettingsAsync();
}