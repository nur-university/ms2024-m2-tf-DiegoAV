using Domain.Entities;
using Domain.Interfaces;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class CalendarioEntregaRepository : ICalendarioEntregaRepository
    {

        private readonly AppDbContext _context;

        public CalendarioEntregaRepository(AppDbContext context)
        {
            _context = context;
        }   
        public async Task<bool> ActualizarHorarioAsync(Guid calendarioId, TimeSpan nuevoHorario)
        {
            var calendario = await _context.CalendariosEntrega.FindAsync(calendarioId);
            if (calendario == null)
                return false;

            var hoy = DateTime.Now.Date;
            var diferencia = (calendario.fecha.Date - hoy).TotalDays;

            if (diferencia < 2)
                throw new InvalidOperationException("El horario solo puede modificarse con al menos 2 días de anticipación.");

            calendario.horarioPreferido = nuevoHorario;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CalendarioEntrega>> ObtenerPorContratoAsync(Guid contratoId)
        {

            return await _context.CalendariosEntrega
                           .Where(c => c.contratoId == contratoId)
                           .OrderBy(c => c.fecha).ToListAsync();

        }
    }
}
