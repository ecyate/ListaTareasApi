using System.Threading.Tasks;
using MongoDB.Driver;
using TareasApi.Domain.Entities;
using TareasApi.Application.Repositories;

namespace TareasApi.Infraestructure.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository()
        {
            var context = new MongoDBContext(); // Se centraliza la conexión aquí
            _usuarios = context.GetCollection<Usuario>("Usuarios");
        }

        public async Task CrearUsuarioAsync(Usuario usuario)
        {
            await _usuarios.InsertOneAsync(usuario);
        }

        public async Task<Usuario?> ObtenerPorCorreoAsync(string correo)
        {
            var filtro = Builders<Usuario>.Filter.Eq(u => u.Correo, correo);
            return await _usuarios.Find(filtro).FirstOrDefaultAsync();
        }
    }
}
