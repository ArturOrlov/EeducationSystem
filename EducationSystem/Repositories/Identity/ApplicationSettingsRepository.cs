using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Repositories.Identity;

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