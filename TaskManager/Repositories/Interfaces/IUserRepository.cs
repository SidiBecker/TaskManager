﻿using TaskManager.Models;

namespace TaskManager.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAll();

        Task<UserModel> GetById(int id);

        Task<UserModel> Create(UserModel user);

        Task<UserModel> Update(UserModel user, int id);

        Task<bool> Delete(int id);
    }
}
