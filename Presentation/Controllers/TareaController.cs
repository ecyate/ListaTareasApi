using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TareasApi.Application.Services;  
using TareasApi.Domain.Entities;


namespace TareasApi.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public  class TareaController : ControllerBase
    {
        public readonly TareaService _service = new();

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> Get(string usuarioId)
        {
            var tareas = await _service.ObtenerTareasPorUsuario(usuarioId);
            return Ok(tareas);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            await _service.CrearTarea(tarea);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.EliminarTarea(id);
            return Ok();
        }
    }
}
                                                                            