using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Persistence
{
    /// <summary>
    /// Las clases al inicio se ponen internal por defecto, CAMBIAR A PUBLIC SI ES NECESARIO o lo que se necesite.
    /// QUITAR LO DE ABAJO SI NO ES NECESARIO, SOLO ES UN EJEMPLO DE CÓMO HACER SEEDING DE DATOS.
    /// No te olvides de llamar al método Seed desde tu código de inicialización de la base de datos. 
    /// by tosMuer
    /// </summary>
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Servicios.Any())
            {
                var servicios = new List<Servicio>
                {
                    new Servicio
                    {
                        Id = Guid.NewGuid(),
                        nombre = "Asesoramiento Nutricional",
                        duracionDias = 15,
                        modalidadRevision = "Quincenal",
                        costo = 150
                    },
                    new Servicio
                    {
                        Id = Guid.NewGuid(),
                        nombre = "Catering Personalizado",
                        duracionDias = 30,
                        modalidadRevision = "Mensual",
                        costo = 280
                    }
                };

                context.Servicios.AddRange(servicios);
                context.SaveChanges();
            }
        }
    }
}
