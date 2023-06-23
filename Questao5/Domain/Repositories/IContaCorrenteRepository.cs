using Questao5.Domain.Entities;

namespace Questao5.Domain.Repositories
{
    public interface IContaCorrenteRepository
    {
        ContaCorrente GetById(int id);
        void AddMovimento(int idContaCorrente, Movimento movimento);
        object ObterPorId(Guid idContaCorrente);
    }
}