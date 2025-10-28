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
    public class ContratoRepository : IContratoRepository
    {
        private readonly AppDbContext _context;

        public ContratoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Contrato> CrearContratoAsync(Contrato contrato)
        {
            _context.Contratos.Add(contrato);
            await _context.SaveChangesAsync();
            return contrato;
        }
        public async Task<Contrato?> ObtenerContratoPorIdAsync(Guid id)
        {
            return await _context.Contratos
                .Include(c => c.servicio)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<IEnumerable<Contrato>> ObtenerContratosPorPacienteAsync(Guid pacienteId)
        {
            return await _context.Contratos
                .Where(c => c.pacienteId == pacienteId)
                .ToListAsync();
        }
        public async Task CancelarContratoAsync(Guid contratoId)
        {
            var contrato = await _context.Contratos.FindAsync(contratoId);
            if (contrato != null)
            {
                contrato.estado = "Cancelado";
                await _context.SaveChangesAsync();
            }
        }
        public async Task<bool> ExisteContratoActivoAsync(Guid pacienteId)
        {
            return await _context.Contratos
                .AnyAsync(c => c.pacienteId == pacienteId && c.estado == "Activo");
        }
        public async Task GuardarCalendarioAsync(IEnumerable<CalendarioEntrega> calendario)
        {
            _context.CalendariosEntrega.AddRange(calendario);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CalendarioEntrega>> ObtenerCalendarioPorContratoAsync(Guid contratoId)
        {
            return await _context.CalendariosEntrega
                .Where(c => c.contratoId == contratoId)
                .OrderBy(c => c.fecha)
                .ToListAsync();
        }

        public async Task<IEnumerable<Contrato>> ObtenerTodosAsync()
        {
            return await _context.Contratos
                .Include(c => c.servicio)
                .OrderByDescending(c => c.fechaInicio)
                .ToListAsync();
        }

    }
}
