using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TareasApi.Application.Services;
using TareasApi.Domain.Entities;
using TareasApi.Security;
using System.Security.Claims;

namespace TareasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService = new();

        // POST: api/Usuario/registrar
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioRegistroRequest request)
        {
            var usuario = new Usuario
            {
                NombreCompleto = request.NombreCompleto,
                Correo = request.Correo
            };

            await _usuarioService.RegistrarUsuarioAsync(usuario, request.Password);
            return Ok("Usuario registrado con éxito");
        }

        // POST: api/Usuario/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuarioLoginRequest request)
        {
            var usuario = await _usuarioService.ValidarCredencialesAsync(request.Correo, request.Password);

            if (usuario == null)
                return Unauthorized("Credenciales inválidas");

            var jwtGenerator = new JwtGenerator();
            var token = jwtGenerator.GenerarToken(usuario);

            return Ok(new { token });
        }
    }

    // DTOs
    public class UsuarioRegistroRequest
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
    }

    public class UsuarioLoginRequest
    {
        public string Correo { get; set; }
        public string Password { get; set; }
    }
}
