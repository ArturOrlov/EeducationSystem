using EducationSystem.Entities.DbModels.Identity;

namespace EducationSystem.Interfaces.IRepositories;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<Role> GetRoleByUser(User user);
}