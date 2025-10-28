using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence
{
    /// <summary>
    /// No te olvides de cambiar internal a public
    /// by tosMuer
    /// </summary>
    public class ServicioRepository : IServicioRepository
    {

        private readonly AppDbContext _context;
        public ServicioRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Servicio>> ObtenerServiciosAsync()
        {
            return await _context.Servicios.ToListAsync();
        }
        public async Task<Servicio?> ObtenerServicioPorIdAsync(Guid id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        public async Task<Servicio> CrearServicioAsync(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();
            return servicio;
        }
    }
}
