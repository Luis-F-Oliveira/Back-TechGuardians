using Back_TechGuardians.Data;
using Back_TechGuardians.Models;
using Back_TechGuardians.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_TechGuardians.Repositorios
{
    public class UserRepositorio : IUserRepositorio
    {
        private readonly SystemDBContext _dbContext;
        public UserRepositorio(SystemDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<UserModel> GetId(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UserModel>> GetAll()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
            UserModel userId = await GetId(id);

            if (userId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não encontrado");
            }

            userId.Name = user.Name;
            userId.Email = user.Email;
            userId.Password = user.Password;

            _dbContext.Users.Update(userId);
            await _dbContext.SaveChangesAsync();

            return userId;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel userId = await GetId(id);

            if (userId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não encontrado");
            }

            _dbContext.Users.Remove(userId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
