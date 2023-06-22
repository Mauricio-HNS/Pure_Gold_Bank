using System;
using System.Globalization;

namespace Questao1
{
    class ContaBancaria
    {
        public int NumeroConta { get; private set; }
        public string NomeTitular { get; set; }
        public double Saldo { get; private set; }

        public ContaBancaria(int numeroConta, string nomeTitular, double depositoInicial = 0.0)
        {
            NumeroConta = numeroConta;
            NomeTitular = nomeTitular;
            Saldo = depositoInicial;
        }

        public void Deposito(double quantia)
        {
            Saldo += quantia;
        }

        public void Saque(double quantia)
        {
            if (Saldo < quantia)
            {
                Console.WriteLine("Saldo insuficiente!");
            }
            else
            {
                Saldo -= quantia + 3.5;
                Console.WriteLine("Saque realizado com sucesso!");
            }
        }

        public override string ToString()
        {
            return "Conta "
                + NumeroConta
                + ", Titular: "
                + NomeTitular
                + ", Saldo: $ "
                + Saldo.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}