using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ContaBancaria.API.Domain.Exceptions;
using Newtonsoft.Json;

namespace ContaBancaria.API.Domain.Models
{
    [Table("contas")]
    public class ContaCorrente : IContaCorrente
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("saldo", TypeName="DECIMAL(18,6)")]
        public decimal Saldo { get; private set; }

        [JsonIgnore]
        public ICollection<Transacao> Transacoes { get; set; }

        private ContaCorrente()
        {
            Saldo = 0m;
        }

        public ContaCorrente(int id, decimal saldo)
        {
            Id = id;
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