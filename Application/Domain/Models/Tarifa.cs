using System;

namespace ContaBancaria.API.Domain.Models
{
    public class Tarifa : Transacao, ITarifa
    {
        public Tarifa(IContaCorrente conta, DateTime dataHora, decimal saldoAnterior, decimal valor, decimal saldoFinal, string descricao) : base(conta, TipoTransacao.Debito, dataHora, saldoAnterior, valor, saldoFinal, descricao)
        {
        }
    }
}