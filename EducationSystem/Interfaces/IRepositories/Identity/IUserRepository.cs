using EducationSystem.Dto.Identity.User;
using EducationSystem.Entities.DbModels.Identity;

namespace EducationSystem.Interfaces.IRepositories.Identity;

public interface IUserRepository : IGenericRepository<User>
{
    Task<List<GetUserDto>> GetByPaginationAsync(UserFilter request);
}