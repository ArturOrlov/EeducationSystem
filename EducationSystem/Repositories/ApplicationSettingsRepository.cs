using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Dictionaries;
using EducationSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Repositories;

public class ApplicationSettingsRepository : GenericRepository<ApplicationSettings>, IApplicationSettingsRepository
{
    public ApplicationSettingsRepository(EducationSystemDbContext context) : base(context)
    {
    }

    public async Task<ApplicationSettings> GetByNameAsync(string name)
    {
        return await _context.ApplicationSettings.FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<List<ApplicationSettings>> GetAllSettingsAsync()
    {
        return await _context.ApplicationSettings.OrderBy(s => s.Id).ToListAsync();
    }
}