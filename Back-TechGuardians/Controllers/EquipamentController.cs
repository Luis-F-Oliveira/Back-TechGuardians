using Back_TechGuardians.Models;
using Back_TechGuardians.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_TechGuardians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentController : ControllerBase
    {
        private readonly IEquipamentRepositorio _equipamentRepositorio;
        public EquipamentController(IEquipamentRepositorio equipamentRepositorio)
        {
            _equipamentRepositorio = equipamentRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<EquipamentModel>>> BuscarTodosUsuarios()
        {
            List<EquipamentModel> equipaments = await _equipamentRepositorio.GetAll();
            return Ok(equipaments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EquipamentModel>> BuscarPorId(int id)
        {
            EquipamentModel equipament = await _equipamentRepositorio.GetId(id);
            return Ok(equipament);
        }

        [HttpPost]
        public async Task<ActionResult<EquipamentModel>> Cadastrar([FromBody] EquipamentModel equipamentModel)
        {
            EquipamentModel equipament = await _equipamentRepositorio.Add(equipamentModel);
            return Ok(equipament);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EquipamentModel>> Atualizar([FromBody] EquipamentModel equipamentModel, int id)
        {
            equipamentModel.Id = id;
            EquipamentModel equipament = await _equipamentRepositorio.Update(equipamentModel, id);
            return Ok(equipament);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<EquipamentModel>> Apagar(int id)
        {
            bool apagado = await _equipamentRepositorio.Delete(id);
            return Ok(apagado);
        }
    }
}
