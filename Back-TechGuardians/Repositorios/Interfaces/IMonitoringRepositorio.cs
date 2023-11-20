using Back_TechGuardians.Models;

namespace Back_TechGuardians.Repositorios.Interfaces
{
    public interface IMonitoringRepositorio
    {
        Task<List<MonitoringModel>> GetAll();
        Task<MonitoringModel> GetId(int id);
        Task<MonitoringModel> Add(MonitoringModel monitoring);
        Task<MonitoringModel> Update(MonitoringModel monitoring, int id);
        Task<bool> Delete(int id);
    }
}
