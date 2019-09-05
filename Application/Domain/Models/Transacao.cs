using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ContaBancaria.API.Domain.Models
{
    [Table("transacoes")]
    public class Transacao : ITransacao
    {
        private IContaCorrente _contaCorrente;

        [Key]
        [Column("id")]
        public long Id { get; protected set; }

        [ForeignKey("Parent")]
        [Column("parent_id")]
        public long? ParentId { get; protected set; }

        public Transacao Parent { get; protected set; }

        [JsonIgnore]
        public int ContaCorrenteId { get; protected set; }

        [JsonIgnore] 
        [ForeignKey("ContaCorrenteId")]
        public ContaCorrente ContaCorrente 
        {
            get { return (ContaCorrente) this._contaCorrente; }
            private set {this._contaCorrente = value; }
        }

        [NotMapped]
        public IContaCorrente Conta { 
            get { return _contaCorrente; }
        }

        [Required]
        [Column("tipo")]
        public TipoTransacao Tipo { get; protected set; }

        [Required]
        [Column("data_hora", TypeName="DATETIME")]
        public DateTime DataHora { get; protected set; }

        [Required]
        [Column("saldo_anterior", TypeName="DECIMAL(18,6)")]
        public decimal SaldoAnterior { get; protected set; }

        [Required]
        [Column("valor", TypeName="DECIMAL(18,6)")]
        public decimal Valor { get; protected set; }

        [Required]
        [Column("saldo_final", TypeName="DECIMAL(18,6)")]
        public decimal SaldoFinal { get; protected set; }

        [Required]
        [Column("descricao", TypeName="VARCHAR(50)")]
        public string Descricao { get; protected set; }

        public Transacao()
        {
        }

        public Transacao(IContaCorrente conta, TipoTransacao tipo, DateTime dataHora, decimal saldoAnterior, decimal valor, decimal saldoFinal, string descricao)
        {
            ContaCorrenteId = conta.Id;
            _contaCorrente = conta;
            Tipo = tipo;
            DataHora = dataHora;
            SaldoAnterior = saldoAnterior;
            Valor = valor;
            SaldoFinal = saldoFinal;
            Descricao = descricao;
        }
    }
}