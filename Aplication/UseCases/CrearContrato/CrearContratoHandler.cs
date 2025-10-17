using Aplication.DTOs;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.CrearContrato
{
    public class CrearContratoHandler : IRequestHandler<CrearContratoCommand, ContratoDto>
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly IServicioRepository _servicioRepository;

        public CrearContratoHandler(IContratoRepository contratoRepository, IServicioRepository servicioRepository)
        {
            _contratoRepository = contratoRepository;
            _servicioRepository = servicioRepository;
        }

        public async Task<ContratoDto> Handle(CrearContratoCommand command, CancellationToken cancellationToken)
        {
            var servicio = await _servicioRepository.ObtenerServicioPorIdAsync(command.Request.ServicioId);
            if (servicio == null)
                throw new Exception("Servicio no encontrado.");

            var contrato = new Contrato
            {
                Id = Guid.NewGuid(),
                pacienteId = command.Request.PacienteId,
                servicioId = servicio.Id,
                fechaInicio = command.Request.FechaInicio,
                fechaFin = command.Request.FechaInicio.AddDays(servicio.duracionDias),
                politicaCambio = command.Request.PoliticaCambio,
                estado = "Activo",
                montoTotal = servicio.costo,
                servicio = servicio
            };

            var creado = await _contratoRepository.CrearContratoAsync(contrato);


            var calendario = new List<CalendarioEntrega>();
            for (int i = 0; i < servicio.duracionDias; i++)
            {
                var fechaEntrega = contrato.fechaInicio.AddDays(i);

                // Si no se entregan fines de semana, omitir sábados y domingos
                if (!servicio.incluyeFinesDeSemana &&
                    (fechaEntrega.DayOfWeek == DayOfWeek.Saturday || fechaEntrega.DayOfWeek == DayOfWeek.Sunday))
                {
                    continue;
                }

                calendario.Add(new CalendarioEntrega
                {
                    Id = Guid.NewGuid(),
                    contratoId = contrato.Id,
                    fecha = fechaEntrega,
                    horarioPreferido = new TimeSpan(8, 0, 0),
                    direccionEntrega = "Dirección genérica",
                    esDiaNoEntrega = false
                });
            }

            await _contratoRepository.GuardarCalendarioAsync(calendario); // obtiene la lista de entregas generada

            return new ContratoDto
            {
                Id = creado.Id,
                PacienteId = creado.pacienteId,
                ServicioId = creado.servicioId,
                FechaInicio = creado.fechaInicio,
                FechaFin = creado.fechaFin,
                Estado = creado.estado,
                MontoTotal = creado.montoTotal
            };
        }
    }
}
