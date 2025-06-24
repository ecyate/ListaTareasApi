using TareasApi.Domain.Entities;
using TareasApi.Infraestructure.Data;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TareasApi.Application.Repositories;

namespace TareasApi.Application.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService()
        {
            _usuarioRepository = new UsuarioRepository(); 
        }

        public async Task RegistrarUsuarioAsync(Usuario usuario, string passwordPlano)
        {
            usuario.PasswordHash = HashPassword(passwordPlano);
            await _usuarioRepository.CrearUsuarioAsync(usuario);
        }

        public async Task<Usuario?> ValidarCredencialesAsync(string correo, string passwordPlano)
        {
            var usuario = await _usuarioRepository.ObtenerPorCorreoAsync(correo);
            if (usuario == null) return null;

            return VerificarPassword(passwordPlano, usuario.PasswordHash) ? usuario : null;
        }

        private bool VerificarPassword(string passwordPlano, string hashGuardado)
        {
            var hashNuevo = HashPassword(passwordPlano);
            return hashNuevo == hashGuardado;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}
