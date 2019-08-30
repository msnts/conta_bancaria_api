using ContaBancaria.API.Domain.Exceptions;

namespace ContaBancaria.API.Domain.Models
{
    public class ContaCorrente : IContaCorrente
    {
        public int Id { get; set; }

        public decimal Saldo { get; private set; }

        private ContaCorrente()
        {
            Saldo = 0m;
        }

        public ContaCorrente(decimal saldo)
        {
            Saldo = saldo;
        }

        public void Depositar(decimal value)
        {
            if (value < 0.01m)
            {
                throw new ValorDeDepositoInvalidoException("Valor de depósito inválido");
            }

            Saldo += value;
        }

        public void Sacar(decimal value)
        {
            if (value < 0.01m)
            {
                throw new ValorDeSaqueInvalidoException("Valor do saque inválido");
            }

            if (value > Saldo)
            {
                throw new SaldoInsuficienteException("Valor de saldo insuficiente");
            }

            Saldo -= value;
        }

        public void Transferir(decimal value, IContaCorrente contaDestino)
        {
            Sacar(value);
            contaDestino.Depositar(value);
        }
    }
}