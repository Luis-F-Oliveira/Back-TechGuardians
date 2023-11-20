using Back_TechGuardians.Models;
using Back_TechGuardians.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_TechGuardians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitoringController : ControllerBase
    {
        private readonly IMonitoringRepositorio _monitoringRepositorio;
        public MonitoringController(IMonitoringRepositorio monitoringRepositorio)
        {
            _monitoringRepositorio = monitoringRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<MonitoringModel>>> BuscarTodosUsuarios()
        {
            List<MonitoringModel> monitorings = await _monitoringRepositorio.GetAll();
            return Ok(monitorings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MonitoringModel>> BuscarPorId(int id)
        {
            MonitoringModel monitoring = await _monitoringRepositorio.GetId(id);
            return Ok(monitoring);
        }

        [HttpPost]
        public async Task<ActionResult<MonitoringModel>> Cadastrar([FromBody] MonitoringModel monitoringModel)
        {
            try
            {
                MonitoringModel monitoring = await _monitoringRepositorio.Add(monitoringModel);
                return Ok(monitoring);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MonitoringModel>> Atualizar([FromBody] MonitoringModel monitoringModel, int id)
        {
            monitoringModel.Id = id;
            MonitoringModel monitoring = await _monitoringRepositorio.Update(monitoringModel, id);
            return Ok(monitoring);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<MonitoringModel>> Apagar(int id)
        {
            bool apagado = await _monitoringRepositorio.Delete(id);
            return Ok(apagado);
        }
    }
}
