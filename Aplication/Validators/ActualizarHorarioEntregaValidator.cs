using Aplication.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Validators
{
    public class ActualizarHorarioEntregaValidator : AbstractValidator<ActualizarHorarioEntregaRequest>
    {
        public ActualizarHorarioEntregaValidator()
        {
            RuleFor(x => x.CalendarioId)
                .NotEmpty().WithMessage("El ID del calendario es obligatorio.");

            RuleFor(x => x.NuevoHorario)
                .NotEmpty().WithMessage("Debe especificar un nuevo horario.")
                .Must(horario => horario >= TimeSpan.FromHours(6) && horario <= TimeSpan.FromHours(22))
                .WithMessage("El horario debe estar entre las 06:00 y las 22:00.");
        }
    }
}
