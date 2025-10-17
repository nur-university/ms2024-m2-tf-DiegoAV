using Aplication.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validators
{
    public class CrearContratoValidator : AbstractValidator<CrearContratoRequest>
    {
        public CrearContratoValidator()
        {
            RuleFor(x => x.PacienteId).NotEmpty();
            RuleFor(x => x.ServicioId).NotEmpty();
            RuleFor(x => x.FechaInicio).GreaterThan(DateTime.Today);
            RuleFor(x => x.PoliticaCambio).NotEmpty().MaximumLength(500);
        }
    }
}
