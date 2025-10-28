using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IServicioRepository
    {
        Task<Servicio> CrearServicioAsync(Servicio servicio);
        Task<IEnumerable<Servicio>> ObtenerServiciosAsync();
        Task<Servicio?> ObtenerServicioPorIdAsync(Guid id);
    }
}
