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
            RuleFor(x => x.PacienteId)
                .NotEmpty().WithMessage("El ID del paciente es obligatorio.");

            RuleFor(x => x.ServicioId)
                .NotEmpty().WithMessage("Debe seleccionar un servicio.");

            RuleFor(x => x.FechaInicio)
                .GreaterThan(DateTime.Today).WithMessage("La fecha de inicio debe ser posterior a hoy.");

            RuleFor(x => x.PoliticaCambio)
                .NotEmpty().WithMessage("Debe especificar la política de cambio.")
                .MaximumLength(500).WithMessage("La política de cambio no debe exceder los 500 caracteres.");

        }

    }
}
