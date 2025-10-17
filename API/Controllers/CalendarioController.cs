using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarioController : ControllerBase
    {
        private readonly IContratoRepository _contratoRepository;

        public CalendarioController(IContratoRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        [HttpGet("{contratoId}")]
        public async Task<IActionResult> ObtenerCalendarioPorContrato(Guid contratoId)
        {
            var calendario = await _contratoRepository.ObtenerCalendarioPorContratoAsync(contratoId);
            if (!calendario.Any())
                return NotFound("No se encontró calendario para el contrato especificado.");

            return Ok(calendario);
        }
    }
}
