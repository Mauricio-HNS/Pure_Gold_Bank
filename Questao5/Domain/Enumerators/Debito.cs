using Questao5.Infrastructure.Services;
using System;

namespace Questao5.Domain
{
    public class Debito
    {
        public Guid Id { get; set; }
        public Guid IdContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public TipoMovimento TipoMovimento { get; set; }
        public decimal Valor { get; set; }

        public Debito(Guid id, Guid idContaCorrente, DateTime dataMovimento, TipoMovimento tipoMovimento, decimal valor)
        {
            Id = id;
            IdContaCorrente = idContaCorrente;
            DataMovimento = dataMovimento;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }

        public void MovimentarContaCorrente()
        {
            // TODO: Implementar lógica para movimentar a conta corrente
        }
    }
}