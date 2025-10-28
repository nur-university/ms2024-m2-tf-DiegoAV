using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IContratoRepository
    {
        Task<Contrato> CrearContratoAsync(Contrato contrato);
        Task<Contrato?> ObtenerContratoPorIdAsync(Guid id);
        Task<IEnumerable<Contrato>> ObtenerTodosAsync();
        Task<IEnumerable<Contrato>> ObtenerContratosPorPacienteAsync(Guid pacienteId);
        Task CancelarContratoAsync(Guid contratoId);
        Task<bool> ExisteContratoActivoAsync(Guid pacienteId);
        Task GuardarCalendarioAsync(IEnumerable<CalendarioEntrega> calendario);
        Task<IEnumerable<CalendarioEntrega>> ObtenerCalendarioPorContratoAsync(Guid contratoId);
    }
}
