using Back_TechGuardians.Models;

namespace Back_TechGuardians.Repositorios.Interfaces
{
    public interface IUserRepositorio
    {
        Task<List<UserModel>> GetAll();
        Task<UserModel> GetId(int id);
        Task<UserModel> Add(UserModel user);
        Task<UserModel> Update(UserModel user, int id);
        Task<bool> Delete(int id);
    }
}
