using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class CrearServicioRequest
    {
        public string nombre { get; set; }
        public int duracionDias { get; set; }
        public string modalidadRevision { get; set; }
        public decimal costo { get; set; }
        public bool incluyeFinesDeSemana { get; set; }

    }
}
