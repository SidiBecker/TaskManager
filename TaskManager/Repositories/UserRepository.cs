using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.Models;
using TaskManager.Repositories.Interfaces;

namespace TaskManager.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly TaskManagerDBContext _dbContext;

        public UserRepository(TaskManagerDBContext taskManagerDBContext)
        {
            _dbContext = taskManagerDBContext;
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<UserModel> Create(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userDb = await GetById(id);

            if (userDb == null)
            {
                throw new Exception($"User {id} not found.");
            }

            userDb.Name = user.Name;
            userDb.Email = user.Email;

            _dbContext.Users.Update(userDb);
            await _dbContext.SaveChangesAsync();

            return userDb;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userDb = await GetById(id);

            if (userDb == null)
            {
                throw new Exception($"User {id} not found.");
            }

            _dbContext.Users.Remove(userDb);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }
}
