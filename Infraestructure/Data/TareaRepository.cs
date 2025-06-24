using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using TareasApi.Application.Repositories;
using TareasApi.Domain.Entities;

namespace TareasApi.Infraestructure.Data
{
    public class TareaRepository : ITareaRepository
    {
        private readonly IMongoCollection<Tarea> _tareas;

        public TareaRepository()
        {
            var context = new MongoDBContext(); // Aquí usas la clase centralizada
            _tareas = context.GetCollection<Tarea>("Tareas");
        }

        public async Task CrearTarea(Tarea tarea)
        {
            await _tareas.InsertOneAsync(tarea);
        }

        public async Task EliminarTarea(string id)
        {
            await _tareas.DeleteOneAsync(t => t.Id == id);
        }

        public async Task<List<Tarea>> ObtenerTareasPorUsuario(string usuarioId)
        {
            var resultado = await _tareas.FindAsync(t => t.UsuarioId == usuarioId);
            return await resultado.ToListAsync();
        }

        public async Task MarcarComoCompletada(string tareaId)
        {
            var update = Builders<Tarea>.Update.Set(t => t.Completada, true);
            await _tareas.UpdateOneAsync(t => t.Id == tareaId, update);
        }
    }
}
