using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;

namespace EducationSystem.Repositories.Identity;

public class UserClaimRepository :  GenericRepository<UserClaim>, IUserClaimRepository
{
    public UserClaimRepository(EducationSystemDbContext context) : base(context)
    {
    }
    
    public async Task RemoveClaim(int id)
    {
        var claim = await _context.UserClaims.FindAsync(id);
        _context.UserClaims.Remove(claim);
        await _context.SaveChangesAsync();
    }
}