using EducationSystem.Context;
using EducationSystem.Entities.DbModels.Identity;
using EducationSystem.Interfaces.IRepositories.Identity;

namespace EducationSystem.Repositories.Identity;

public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
{
    public DeviceRepository(EducationSystemDbContext context) : base(context)
    {
    }

    public Device GetByUserId(int userId)
    {
        return Get(d => d.UserId == userId).FirstOrDefault();
    }
}