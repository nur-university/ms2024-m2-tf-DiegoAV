using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class ActualizarHorarioEntregaRequest
    {
        public Guid CalendarioId { get; set; }
        public TimeSpan NuevoHorario { get; set; }
    }
}
