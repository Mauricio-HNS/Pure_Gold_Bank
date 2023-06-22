using Questao5.Infrastructure.Services;

namespace Questao5.Domain.Entities
{
    public class Movimento
    {
        public int IdContaCorrente { get; internal set; }
        public DateTime DataMovimento { get; internal set; }
        public decimal Valor { get; internal set; }
        public TipoMovimento TipoMovimento { get; internal set; }
        public int IdMovimento { get; internal set; }
    }
}