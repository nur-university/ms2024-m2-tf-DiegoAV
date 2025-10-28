using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Servicio
    {
        public Guid Id { get; set; }
        public string nombre { get; set; } // Asesoramiento o Catering
        public int duracionDias { get; set; } // 15 o 30 días
        public string modalidadRevision { get; set; } // Quincenal, Mensual
        public decimal costo { get; set; }
        public bool incluyeFinesDeSemana { get; set; } // ← Aquí True si incluye o False no incluye

    }
}
