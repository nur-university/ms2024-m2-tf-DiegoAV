using Aplication.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validators
{
    public class CrearServicioValidator : AbstractValidator<CrearServicioRequest>
    {
        public CrearServicioValidator()
        {
            RuleFor(x => x.nombre)
                .NotEmpty().WithMessage("El nombre del servicio es obligatorio.")
                .MaximumLength(100).WithMessage("El nombre no debe exceder los 100 caracteres.");

            RuleFor(x => x.duracionDias)
                .GreaterThan(0).WithMessage("La duración debe ser mayor a 0 días.")
                .LessThanOrEqualTo(60).WithMessage("La duración no debe exceder los 60 días.");

            RuleFor(x => x.modalidadRevision)
                .NotEmpty().WithMessage("Debe especificar la modalidad de revisión.")
                .MaximumLength(50).WithMessage("La modalidad no debe exceder los 50 caracteres.");

            RuleFor(x => x.costo)
                .GreaterThan(0).WithMessage("El costo debe ser mayor a 0.");

            RuleFor(x => x.incluyeFinesDeSemana)
                .NotNull().WithMessage("Debe indicar si el servicio incluye fines de semana.");
        }

    }
}
