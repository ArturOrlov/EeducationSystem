using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Repositories.Identity;

public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshTokenRepository
{
    public RefreshTokenRepository(EducationSystemDbContext context) : base(context)
    {
    }

    public RefreshToken GetByDeviceId(int deviceId)
    {
        return Get(rt => rt.DeviceId == deviceId).FirstOrDefault();
    }

    public RefreshToken FindByToken(string token)
    {
        return Get(rt => rt.Token == token).FirstOrDefault();
    }

    public User GetUserByTokenId(int tokenId)
    {
        var token = _context.RefreshToken
            .Include(t => t.Device)
            .ThenInclude(d => d.User)
            .FirstOrDefault(tok => tok.Id == tokenId);

        return token.Device.User;
    }
}