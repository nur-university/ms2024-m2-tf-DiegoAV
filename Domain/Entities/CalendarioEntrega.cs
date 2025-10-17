using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CalendarioEntrega
    {

        public Guid Id { get; set; }
        public Guid contratoId { get; set; }
        public DateTime fecha { get; set; }
        public TimeSpan horarioPreferido { get; set; }
        public string direccionEntrega { get; set; }
        public bool esDiaNoEntrega { get; set; }
        public Contrato contrato { get; set; }

    }
}
