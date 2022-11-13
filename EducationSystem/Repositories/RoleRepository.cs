using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories;

namespace EducationSystem.Repositories;

public class RoleRepository :  GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(EducationSystemDbContext context) : base(context)
    {
    }

    public async Task<Role> GetRoleByUser(User user)
    {
        // var query = new QueryFactory(_connection, _compiler)
        //     .Query("identity.UserRole as ur")
        //     .Select("r.Id as Id", "r.Name as Name")
        //     .Where("ur.UserId", user.Id)
        //     .Join("identity.Role as r", "r.Id", "ur.RoleId")
        //     .Get<IdentityRole<int>>()
        //     .FirstOrDefault();
        // return query;

        return new Role();
    }
}