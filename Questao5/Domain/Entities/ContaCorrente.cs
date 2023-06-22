using System.Collections.Generic;

namespace Questao5.Domain.Entities
{
    public class ContaCorrente
    {
        public int Id { get; set; }
        public decimal Saldo { get; set; }
        public List<Movimento> Movimentos { get; set; }
        public bool Ativo { get; internal set; }
    }
}