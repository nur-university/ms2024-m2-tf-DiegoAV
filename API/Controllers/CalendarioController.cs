using Aplication.DTOs;
using Domain.Interfaces;
using FluentValidation;
using Infraestructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalendarioController : ControllerBase
    {
        private readonly ICalendarioEntregaRepository _calendarioRepository;

        public CalendarioController(ICalendarioEntregaRepository calendarioRepository)
        {
            _calendarioRepository = calendarioRepository;
        }


        [HttpGet("{contratoId}")]
        public async Task<IActionResult> ObtenerCalendarioPorContrato(Guid contratoId)
        {
            var calendario = await _calendarioRepository.ObtenerPorContratoAsync(contratoId);
            if (!calendario.Any())
                return NotFound("No se encontró calendario para el contrato especificado.");

            var resultado = calendario.Select(c => new CalendarioEntregaDto
            {
                Id = c.Id,
                fecha = c.fecha,
                diaSemana = c.fecha.ToString("dddd"),
                horario = c.horarioPreferido.ToString(@"hh\:mm"),
                direccionEntrega = c.direccionEntrega,
                esDiaNoEntrega = c.esDiaNoEntrega
            });

            return Ok(resultado);
        }

        //[HttpPut("actualizar-horario")]
        //public async Task<IActionResult> ActualizarHorario([FromBody] ActualizarHorarioEntregaRequest request)
        //{
        //    try
        //    {
        //        var actualizado = await _calendarioRepository.ActualizarHorarioAsync(request.CalendarioId, request.NuevoHorario);
        //        if (!actualizado)
        //            return NotFound("No se encontró el registro de calendario.");

        //        return Ok("Horario actualizado correctamente.");
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        [HttpPut("actualizar-horario")]
        public async Task<IActionResult> ActualizarHorario([FromBody] ActualizarHorarioEntregaRequest request,[FromServices] IValidator<ActualizarHorarioEntregaRequest> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            try
            {
                var actualizado = await _calendarioRepository.ActualizarHorarioAsync(request.CalendarioId, request.NuevoHorario);
                if (!actualizado)
                    return NotFound("No se encontró el registro de calendario.");

                return Ok("Horario actualizado correctamente.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
