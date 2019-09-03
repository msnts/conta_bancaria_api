using System.Collections.Generic;
using ContaBancaria.API.Domain.Exceptions;

namespace ContaBancaria.API.Domain.Models
{
    public class ContaCorrente : IContaCorrente
    {
        public int Id { get; set; }

        public decimal Saldo { get; private set; }

        public ICollection<Transacao> Transacoes { get; set; }

        private ContaCorrente()
        {
            Saldo = 0m;
        }

        public ContaCorrente(decimal saldo)
        {
            Saldo = saldo;
        }

        public void Creditar(decimal value)
        {
            if (value < 0.01m)
            {
                throw new ValorDeCreditoInvalidoException("Valor de crédito inválido");
            }

            Saldo += value;
        }

        public void Debitar(decimal value)
        {
            if (value < 0.01m)
            {
                throw new ValorDeDebitoInvalidoException("Valor do débito inválido");
            }

            if (value > Saldo)
            {
                throw new SaldoInsuficienteException("Valor de débito insuficiente");
            }

            Saldo -= value;
        }

        public void Transferir(decimal value, IContaCorrente contaDestino)
        {
            Debitar(value);
            contaDestino.Creditar(value);
        }
    }
}