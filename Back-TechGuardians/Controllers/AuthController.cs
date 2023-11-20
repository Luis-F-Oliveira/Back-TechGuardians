using Back_TechGuardians.Models;
using Back_TechGuardians.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Back_TechGuardians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        
        private readonly IUserRepositorio _usuarioRepositorio;
        public AuthController(IUserRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<UserModel>> Login()
        {
            List<UserModel> users = await _usuarioRepositorio.GetAll();
            return Ok(users);
        }
    }
}
