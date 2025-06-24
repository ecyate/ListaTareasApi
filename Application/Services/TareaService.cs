using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TareasApi.Application.Repositories;
using TareasApi.Domain.Entities;
using TareasApi.Infraestructure.Data;

namespace TareasApi.Application.Services
{
    public class TareaService
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaService()
        {
            _tareaRepository = new TareaRepository(); 
        }

        public async Task<List<Tarea>> ObtenerTareasPorUsuario(string usuarioId)
        {
            return await _tareaRepository.ObtenerTareasPorUsuario(usuarioId);
        }

        public async Task CrearTarea(Tarea tarea)
        {
            await _tareaRepository.CrearTarea(tarea);
        }

        public async Task EliminarTarea(string tareaId)
        {
            await _tareaRepository.EliminarTarea(tareaId);
        }

        public async Task MarcarComoCompletada(string tareaId)
        {
            await _tareaRepository.MarcarComoCompletada(tareaId);
        }
    }
}
