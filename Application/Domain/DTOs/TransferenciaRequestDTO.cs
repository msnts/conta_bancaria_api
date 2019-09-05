using System;
using System.ComponentModel.DataAnnotations;

namespace ContaBancaria.API.Domain.DTOs
{
    public class TransferenciaRequestDTO
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ContaOrigemId { get; }

        [Required]
        [Range(1, Int32.MaxValue)]
        public int ContaDestinoId { get; }

        [Required]
        [Range(0.01, 999999999999.99)]
        public decimal Valor { get; }

        public TransferenciaRequestDTO(int contaOrigemId, int contaDestinoId, decimal valor)
        {
            ContaOrigemId = contaOrigemId;
            ContaDestinoId = contaDestinoId;
            Valor = valor;
        }
    }
}