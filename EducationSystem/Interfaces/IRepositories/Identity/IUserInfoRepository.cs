﻿using EducationSystem.Entities.DbModels.Identity;

namespace EducationSystem.Interfaces.IRepositories.Identity;

public interface IUserInfoRepository : IGenericRepository<UserInfo>
{
    Task<UserInfo> GetByUserId(int userId);
}