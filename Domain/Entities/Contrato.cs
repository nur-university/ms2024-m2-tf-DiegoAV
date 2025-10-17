using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Contrato
    {

        public Guid Id { get; set; }
        public Guid pacienteId { get; set; }
        public Guid servicioId { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string politicaCambio { get; set; }
        public string estado { get; set; } // Activo, Cancelado, Finalizado
        public decimal montoTotal { get; set; }
        public Servicio servicio { get; set; }
        public bool incluyeFinesDeSemana { get; set; }
    }
}
