using Back_TechGuardians.Data;
using Back_TechGuardians.Models;
using Back_TechGuardians.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_TechGuardians.Repositorios
{
    public class MonitoringRepositorio : IMonitoringRepositorio
    {
        private readonly SystemDBContext _dbContext;
        public MonitoringRepositorio(SystemDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<MonitoringModel>> GetAll()
        {
            return await _dbContext.Monitorings.ToListAsync();
        }

        public async Task<MonitoringModel> GetId(int id)
        {
            return await _dbContext.Monitorings.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<MonitoringModel> Add(MonitoringModel monitoring)
        {
            await _dbContext.Monitorings.AddAsync(monitoring);
            await _dbContext.SaveChangesAsync();

            return monitoring;
        }

        public async Task<bool> Delete(int id)
        {
            MonitoringModel monintoringId = await GetId(id);

            if (monintoringId == null)
            {
                throw new Exception($"Monitoring para o ID: {id} não encontrado");
            }

            _dbContext.Monitorings.Remove(monintoringId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<MonitoringModel> Update(MonitoringModel monitoring, int id)
        {
            MonitoringModel monitoringId = await GetId(id);

            if (monitoringId == null)
            {
                throw new Exception($"Monitoring para o ID: {id} não encontrado");
            }

            monitoringId.Block = monitoring.Block;
            monitoringId.Room = monitoring.Room;

            _dbContext.Monitorings.Update(monitoringId);
            await _dbContext.SaveChangesAsync();

            return monitoringId;
        }
    }
}
