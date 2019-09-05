using System;

namespace ContaBancaria.API.Domain.Models
{
    public class CreditoTransferencia : Transacao, ICreditoTransferencia
    {
        private const string DESCRICAO_TRANSACAO = "Crédito de Transferência";

        public CreditoTransferencia(ITransacao parent, IContaCorrente conta, DateTime dataHora, decimal saldoAnterior, decimal valor, decimal saldoFinal) : base(conta, TipoTransacao.Credito, dataHora, saldoAnterior, valor, saldoFinal, DESCRICAO_TRANSACAO)
        {
            Parent = (Transacao) parent;
        }
    }
}