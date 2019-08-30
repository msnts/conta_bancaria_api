using System;

namespace ContaBancaria.API.Domain.Models
{
    public enum TipoTransacao { Credito, Debito }

    public interface ITransacao
    {
        long Id { get; }

        IContaCorrente ContaOrigem { get; }

        IContaCorrente ContaDestino { get; }

        TipoTransacao Tipo { get; }

        DateTime DataHora { get; }

        decimal SaldoAnterior { get; }

        decimal Valor { get; }

        decimal SaldoFinal { get; }

        string Descricao { get; }

    }
}