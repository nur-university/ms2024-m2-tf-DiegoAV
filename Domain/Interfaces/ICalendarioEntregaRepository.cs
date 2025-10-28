using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICalendarioEntregaRepository
    {
        Task<IEnumerable<CalendarioEntrega>> ObtenerPorContratoAsync(Guid contratoId);
        Task<bool> ActualizarHorarioAsync(Guid calendarioId, TimeSpan nuevoHorario);
    }
}
