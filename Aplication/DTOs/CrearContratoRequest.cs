using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.DTOs
{
    public class CrearContratoRequest
    {
        public Guid PacienteId { get; set; }
        public Guid ServicioId { get; set; }
        public DateTime FechaInicio { get; set; }
        public string PoliticaCambio { get; set; }
    }
}
