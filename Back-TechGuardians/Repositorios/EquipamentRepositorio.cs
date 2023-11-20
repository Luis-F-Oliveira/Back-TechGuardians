using Back_TechGuardians.Data;
using Back_TechGuardians.Models;
using Back_TechGuardians.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_TechGuardians.Repositorios
{
    public class EquipamentRepositorio : IEquipamentRepositorio
    {
        private readonly SystemDBContext _dbContext;
        public EquipamentRepositorio(SystemDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        public async Task<List<EquipamentModel>> GetAll()
        {
            return await _dbContext.Equipaments.ToListAsync();
        }

        public async Task<EquipamentModel> GetId(int id)
        {
            return await _dbContext.Equipaments.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EquipamentModel> Update(EquipamentModel equipament, int id)
        {
            EquipamentModel equipamentId = await GetId(id);

            if (equipamentId == null)
            {
                throw new Exception($"Equipament para o ID: {id} não encontrado");
            }

            equipamentId.Name = equipament.Name;
            equipament.Description = equipament.Description;

            _dbContext.Equipaments.Update(equipamentId);
            await _dbContext.SaveChangesAsync();

            return equipamentId;
        }
        
        public async Task<EquipamentModel> Add(EquipamentModel equipament)
        {
            await _dbContext.Equipaments.AddAsync(equipament);
            await _dbContext.SaveChangesAsync();

            return equipament;
        }

        public async Task<bool> Delete(int id)
        {
            EquipamentModel equipamentId = await GetId(id);

            if (equipamentId == null)
            {
                throw new Exception($"Equipament para o ID: {id} não encontrado");
            }

            _dbContext.Equipaments.Remove(equipamentId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
