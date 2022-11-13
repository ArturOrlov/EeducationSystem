using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Repositories;

public class UserInfoRepository : GenericRepository<UserInfo>, IUserInfoRepository
{
    public UserInfoRepository(EducationSystemDbContext context) : base(context)
    {
    }

    public async Task<UserInfo> GetByUserId(int userId)
    {
        return await _context.UserInfo.FirstOrDefaultAsync(ui => ui.UserId == userId);
    }
}