using EducationSystem.Context;
using EducationSystem.Dto.Identity.User;
using EducationSystem.Dto.Identity.UserInfo;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EducationSystem.Repositories.Identity;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserRepository(EducationSystemDbContext context,
        UserManager<User> userManager,
        IMapper mapper) : base(context)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<List<GetUserDto>> GetByPaginationAsync(UserFilter request)
    {
        return await (from u in _userManager.Users
            join ur in _context.UserRole on u.Id equals ur.UserId
            join ui in _context.UserInfo on u.Id equals ui.UserId into uid
            from ui in uid.DefaultIfEmpty()
            where request.RoleId == 0 || ur.RoleId == request.RoleId
            select new GetUserDto
            {
                Id = u.Id,
                RoleId = ur.RoleId,
                Email = u.Email,
                UserName = u.UserName,
                PhoneNumber = u.PhoneNumber,
                UserInfo = _mapper.Map<GetUserInfoDto>(ui)
            }).Skip(request.Skip).Take(request.Take).ToListAsync();
    }
}