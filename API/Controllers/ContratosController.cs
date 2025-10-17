using Aplication.DTOs;
using Aplication.UseCases.CrearContrato;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContratosController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ContratosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CrearContrato([FromBody] CrearContratoRequest request)
        {
            var command = new CrearContratoCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}
