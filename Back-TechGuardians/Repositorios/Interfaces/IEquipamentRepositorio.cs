using Back_TechGuardians.Models;

namespace Back_TechGuardians.Repositorios.Interfaces
{
    public interface IEquipamentRepositorio
    {
        Task<List<EquipamentModel>> GetAll();
        Task<EquipamentModel> GetId(int id);
        Task<EquipamentModel> Add(EquipamentModel equipament);
        Task<EquipamentModel> Update(EquipamentModel equipament, int id);
        Task<bool> Delete(int id);
    }
}
