using System;

namespace ContaBancaria.API.Domain.Models
{
    public class Deposito : Transacao, IDeposito
    {
        private const decimal TAXA_DEPOSITO = 0.01m;
        private const string DESCRICAO_TARIFA = "Tarifa de depósito";

        public ITarifa Tarifa { get; private set; }

        public Deposito(IContaCorrente conta, DateTime dataHora, decimal saldoAnterior, decimal valor, decimal saldoFinal) : base(conta, TipoTransacao.Credito, dataHora, saldoAnterior, valor, saldoFinal, "Depósito")
        {
        }

        public ITarifa CalcularTarifa()
        {
            var valorTarifa = DoCalcularTarifa();

            this.Conta.Debitar(valorTarifa);

            this.Tarifa = new Tarifa(this.Conta, this.DataHora, this.SaldoFinal, valorTarifa, this.Conta.Saldo, DESCRICAO_TARIFA);

            return this.Tarifa;
        }

        private decimal DoCalcularTarifa() => Decimal.Round(this.Valor * TAXA_DEPOSITO, 2);
    }
}