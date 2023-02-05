using EducationSystem.Entities.DbModels.Identity;

namespace EducationSystem.Interfaces.IRepositories.Identity;

public interface IApplicationSettingsRepository : IGenericRepository<ApplicationSettings>
{
    Task<ApplicationSettings> GetByNameAsync(string name);
    Task<List<ApplicationSettings>> GetAllSettingsAsync();
}