using EducationSystem.Entities.DbModels.Identity;

namespace EducationSystem.Interfaces.IRepositories;

public interface IDeviceRepository : IGenericRepository<Device>
{
    /// <summary>
    /// Получить данные об устройстве по UserId
    /// </summary>
    /// <param name="userId">идентификатор пользователя</param>
    /// <returns>Данные устройства</returns>
    Device GetByUserId(int userId);
}