using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ContaBancaria.API.Domain.Models
{
    [Table("transacoes")]
    public class Transacao : ITransacao
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }

        [JsonIgnore]
        public int ContaCorrenteId { get; set; }

        //[JsonIgnore]
        [ForeignKey("ContaCorrenteId")]
        public IContaCorrente Conta { get; set; }

        /*[NotMapped]
         IContaCorrente ITransacao.Conta { 
            get { return Conta; }
        }*/

        [Required]
        [Column("tipo")]
        public TipoTransacao Tipo { get; set; }

        [Required]
        [Column("data_hora", TypeName="DATETIME")]
        public DateTime DataHora { get; set; }

        [Required]
        [Column("saldo_anterior", TypeName="DECIMAL(18,6)")]
        public decimal SaldoAnterior { get; set; }

        [Required]
        [Column("valor", TypeName="DECIMAL(18,6)")]
        public decimal Valor { get; set; }

        [Required]
        [Column("saldo_final", TypeName="DECIMAL(18,6)")]
        public decimal SaldoFinal { get; set; }

        [Required]
        [Column("descricao", TypeName="VARCHAR(50)")]
        public string Descricao { get; set; }

        public Transacao()
        {
        }

        public Transacao(IContaCorrente conta, TipoTransacao tipo, DateTime dataHora, decimal saldoAnterior, decimal valor, decimal saldoFinal, string descricao)
        {
            ContaCorrenteId = conta.Id;
            Conta = conta;
            Tipo = tipo;
            DataHora = dataHora;
            SaldoAnterior = saldoAnterior;
            Valor = valor;
            SaldoFinal = saldoFinal;
            Descricao = descricao;
        }

        
    }
}