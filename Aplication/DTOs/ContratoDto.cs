using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class ContratoDto
    {
        public Guid Id { get; set; }
        public Guid PacienteId { get; set; }
        public Guid ServicioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Estado { get; set; }
        public decimal MontoTotal { get; set; }

    }
}
