using EducationSystem.Entities.DbModels.Identity;

namespace EducationSystem.Interfaces.IRepositories;

public interface IVerificationTokenRepository : IGenericRepository<VerificationToken>
{
    public VerificationToken FindByTokenAsync(string token, int maxHoursLife);
}