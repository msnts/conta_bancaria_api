using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaBancaria.API.Domain.Models
{
    public class Tarifa : Transacao, ITarifa
    {
        public Tarifa(Transacao parent, IContaCorrente conta, DateTime dataHora, decimal saldoAnterior, decimal valor, decimal saldoFinal, string descricao) : base(conta, TipoTransacao.Debito, dataHora, saldoAnterior, valor, saldoFinal, descricao)
        {
            Parent = parent;
        }
    }
}