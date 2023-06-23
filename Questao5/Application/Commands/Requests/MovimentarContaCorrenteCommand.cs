using System;
using MediatR;
using Questao5.Domain;
using Questao5.Infrastructure.Services;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentarContaCorrenteCommand : IRequest
    {
        public Guid IdContaCorrente { get; set; }
        public TipoMovimento TipoMovimento { get; set; }
        public decimal Valor { get; set; }
    }
}