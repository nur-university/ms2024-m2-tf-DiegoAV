using Aplication.DTOs;
using Aplication.UseCases.CrearContrato;
using Domain.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ContratosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IContratoRepository _contratoRepository;


        //public ContratosController(IMediator mediator)
        //{
        //    _mediator = mediator;
        //}
        public ContratosController(IMediator mediator, IContratoRepository contratoRepository)
        {
            _mediator = mediator;
            _contratoRepository = contratoRepository ?? throw new ArgumentNullException(nameof(contratoRepository));
        }


        //[HttpPost]
        //public async Task<IActionResult> CrearContrato([FromBody] CrearContratoRequest request)
        //{
        //    var command = new CrearContratoCommand(request);
        //    var result = await _mediator.Send(command);
        //    return Ok(result);
        //}

        [HttpPost]
        public async Task<IActionResult> CrearContrato([FromBody] CrearContratoRequest request, [FromServices] IValidator<CrearContratoRequest> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            var command = new CrearContratoCommand(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var contratos = await _contratoRepository.ObtenerTodosAsync();

            var resultado = contratos.Select(c => new ContratoDto
            {
                Id = c.Id,
                PacienteId = c.pacienteId,
                ServicioId = c.servicioId,
                NombreServicio = c.servicio?.nombre ?? "Desconocido",
                FechaInicio = c.fechaInicio,
                FechaFin = c.fechaFin,
                Estado = c.estado,
                MontoTotal = c.montoTotal
            });

            return Ok(resultado);
        }

    }
}
