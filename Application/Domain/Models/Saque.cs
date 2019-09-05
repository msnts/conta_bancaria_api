using System;

namespace ContaBancaria.API.Domain.Models
{
    public class Saque : Transacao, ISaque
    {
        private const decimal TARIFA_SAQUE = 4.0m;

        private const string DESCRICAO_TARIFA = "Tarifa de saque";
        private const string DESCRICAO_TRANSACAO = "Saque";

        public Saque(IContaCorrente conta, DateTime dataHora, decimal saldoAnterior, decimal valor, decimal saldoFinal) : base(conta, TipoTransacao.Debito, dataHora, saldoAnterior, valor, saldoFinal, DESCRICAO_TRANSACAO)
        {
        }

        public ITarifa Tarifa { get; private set; }

        public ITarifa CalcularTarifa()
        {
            this.Conta.Debitar(TARIFA_SAQUE);

            this.Tarifa = new Tarifa(this, this.Conta, this.DataHora, this.SaldoFinal, TARIFA_SAQUE, this.Conta.Saldo, DESCRICAO_TARIFA);

            return this.Tarifa;
        }
    }
}