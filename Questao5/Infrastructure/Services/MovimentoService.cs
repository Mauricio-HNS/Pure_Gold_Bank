using System;
using Questao5.Domain.Entities;
using Questao5.Domain.Repositories;

namespace Questao5.Infrastructure.Services
{
    public class MovimentoService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public MovimentoService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public int MovimentarContaCorrente(int idContaCorrente, decimal valor, TipoMovimento tipoMovimento)
        {
            // Busca a conta corrente correspondente ao ID informado
            var contaCorrente = _contaCorrenteRepository.GetById(idContaCorrente);

            // Verifica se a conta corrente existe e está ativa
            if (contaCorrente == null || !contaCorrente.Ativo)
                throw new Exception("Conta corrente não encontrada ou inativa.");

            // Verifica se o valor a ser movimentado é positivo
            if (valor <= 0)
                throw new Exception("O valor da movimentação deve ser positivo.");

            // Verifica se o tipo de movimento é válido
            if (tipoMovimento != TipoMovimento.Credito && tipoMovimento != TipoMovimento.Debito)
                throw new Exception("Tipo de movimento inválido.");

            // Cria um objeto Movimento com as informações recebidas
            var movimento = new Movimento
            {
                IdContaCorrente = idContaCorrente,
                DataMovimento = DateTime.Now,
                Valor = valor,
                TipoMovimento = tipoMovimento
            };

            // Adiciona o movimento à lista de movimentos da conta corrente
            contaCorrente.Movimentos.Add(movimento);

            // Persiste o movimento no banco de dados utilizando o método AddMovimento da classe ContaCorrenteRepository
            _contaCorrenteRepository.AddMovimento(idContaCorrente, movimento);

            // Retorna o ID do movimento gerado
            return movimento.IdMovimento;
        }
    }
}