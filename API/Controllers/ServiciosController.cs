using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosController : ControllerBase
    {
        private readonly IServicioRepository _servicioRepository;

        public ServiciosController(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerServicios()
        {
            var servicios = await _servicioRepository.ObtenerServiciosAsync();
            return Ok(servicios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerServicioPorId(Guid id)
        {
            var servicio = await _servicioRepository.ObtenerServicioPorIdAsync(id);
            if (servicio == null)
                return NotFound();

            return Ok(servicio);
        }

    }
}
