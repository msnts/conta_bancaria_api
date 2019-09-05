using System;

namespace ContaBancaria.API.Domain.Models
{
    public class DebitoTransferencia : Transacao, IDebitoTransferencia
    {
        private const string DESCRICAO_TRANSACAO = "Débito de Transferência";
        private const string DESCRICAO_TARIFA = "Tarifa de transferência";
        private const decimal VALOR_TARIFA = 1.0m;

        public ITarifa Tarifa { get; private set; }

        public DebitoTransferencia(IContaCorrente conta, DateTime dataHora, decimal saldoAnterior, decimal valor, decimal saldoFinal) : base(conta, TipoTransacao.Debito, dataHora, saldoAnterior, valor, saldoFinal, DESCRICAO_TRANSACAO)
        {
        }

        public ITarifa CalcularTarifa()
        {
            this.Conta.Debitar(VALOR_TARIFA);

            this.Tarifa = new Tarifa(this, this.Conta, this.DataHora, this.SaldoFinal, VALOR_TARIFA, this.Conta.Saldo, DESCRICAO_TARIFA);

            return this.Tarifa;
        }
    }
}