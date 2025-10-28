using Aplication.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using FluentValidation;
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

        //[HttpPost]
        //public async Task<IActionResult> CrearServicio([FromBody] CrearServicioRequest request)
        //{
        //    var servicio = new Servicio
        //    {
        //        Id = Guid.NewGuid(),
        //        nombre = request.nombre,
        //        duracionDias = request.duracionDias,
        //        modalidadRevision = request.modalidadRevision,
        //        costo = request.costo,
        //        incluyeFinesDeSemana = request.incluyeFinesDeSemana
        //    };

        //    var creado = await _servicioRepository.CrearServicioAsync(servicio);
        //    return Ok(creado);
        //}

        [HttpPost]
        public async Task<IActionResult> CrearServicio([FromBody] CrearServicioRequest request, [FromServices] IValidator<CrearServicioRequest> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            var servicio = new Servicio
            {
                Id = Guid.NewGuid(),
                nombre = request.nombre,
                duracionDias = request.duracionDias,
                modalidadRevision = request.modalidadRevision,
                costo = request.costo,
                incluyeFinesDeSemana = request.incluyeFinesDeSemana
            };

            var creado = await _servicioRepository.CrearServicioAsync(servicio);
            return Ok(creado);
        }
    }
}
