using System.Collections.Generic;

using TareasApi.Domain.Entities;
   using System.Linq;
using TareasApi.Infraestructure.Data;

namespace TareasApi.Application.Repositories
{
    public interface ITareaRepository
    {
        
            Task<List<Tarea>> ObtenerTareasPorUsuario(string usuarioId);
            Task CrearTarea(Tarea tarea);
            Task EliminarTarea(string tareaId);
            Task MarcarComoCompletada(string tareaId);
        }

    }

