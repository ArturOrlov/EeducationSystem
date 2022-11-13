using EducationSystem.Entities.DbModels.Identity;

namespace EducationSystem.Interfaces.IRepositories;

public interface IRefreshTokenRepository : IGenericRepository<RefreshToken>
{
    RefreshToken GetByDeviceId(int deviceId);

    RefreshToken FindByToken(string token);

    User GetUserByTokenId(int tokenId);
}