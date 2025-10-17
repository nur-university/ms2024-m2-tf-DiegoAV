using Aplication.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCases.CrearContrato
{
    public class CrearContratoCommand : IRequest<ContratoDto>
    {
        public CrearContratoRequest Request { get; }

        public CrearContratoCommand(CrearContratoRequest request)
        {
            Request = request;
        }
    }
}
