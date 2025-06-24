using System.Threading.Tasks;
using TareasApi.Domain.Entities;

namespace TareasApi.Application.Repositories
{
    public  interface IUsuarioRepository
    {
 
            Task CrearUsuarioAsync(Usuario usuario);
            Task<Usuario?> ObtenerPorCorreoAsync(string correo);
        }
    }

