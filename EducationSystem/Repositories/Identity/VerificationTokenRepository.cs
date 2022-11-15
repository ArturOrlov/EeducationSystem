using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;

namespace EducationSystem.Repositories.Identity;

public class VerificationTokenRepository : GenericRepository<VerificationToken>, IVerificationTokenRepository
{
    public VerificationTokenRepository(EducationSystemDbContext context) : base(context)
    {
    }

    public VerificationToken FindByTokenAsync(string token, int maxHoursLife)
    {
        return Get(h => h.Token == token && DateTime.UtcNow.AddHours(-1 * maxHoursLife) < h.CreatedAt)
            .FirstOrDefault();
    }
}