using System;

namespace ContaBancaria.API.Domain.Models
{
    public class Transacao : ITransacao
    {
        public long Id { get; }

        public IContaCorrente ContaOrigem { get; }

        public IContaCorrente ContaDestino { get; }

        public TipoTransacao Tipo { get; }

        public DateTime DataHora { get; }

        public decimal SaldoAnterior { get; }

        public decimal Valor { get; }

        public decimal SaldoFinal { get; }

        public string Descricao { get; }
    }
}