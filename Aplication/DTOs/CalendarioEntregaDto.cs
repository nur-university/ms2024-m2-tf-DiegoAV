using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class CalendarioEntregaDto
    {

        public Guid Id { get; set; }
        public DateTime fecha { get; set; }
        public string diaSemana { get; set; }
        public string horario { get; set; }
        public string direccionEntrega { get; set; }
        public bool esDiaNoEntrega { get; set; }

    }
}
