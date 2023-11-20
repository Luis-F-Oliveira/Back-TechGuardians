using Back_TechGuardians.Models;
using Back_TechGuardians.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_TechGuardians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepositorio _usuarioRepositorio;
        public UserController(IUserRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(string email, string password)
        {
            List<UserModel> usuarios = await _usuarioRepositorio.GetAll();
            UserModel usuario = usuarios.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (usuario != null)
            {
                return Ok(new { Message = "Credenciais válidas", Usuario = usuario });
            }
            else
            {
                return Unauthorized("Credenciais inválidas");
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> BuscarTodosUsuarios()
        {
            List<UserModel> usuarios = await _usuarioRepositorio.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> BuscarPorId(int id)
        {
            UserModel usuario = await _usuarioRepositorio.GetId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Cadastrar([FromBody] UserModel usuarioModel)
        {
            UserModel usuario = await _usuarioRepositorio.Add(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserModel>> Atualizar([FromBody] UserModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UserModel usuario = await _usuarioRepositorio.Update(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Apagar(int id)
        {
            bool apagado = await _usuarioRepositorio.Delete(id);
            return Ok(apagado);
        }
    }
}
