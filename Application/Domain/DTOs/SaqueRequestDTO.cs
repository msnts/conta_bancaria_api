using System;
using System.ComponentModel.DataAnnotations;

namespace ContaBancaria.API.Domain.DTOs
{
    public class SaqueRequestDTO
    {
        [Required]
        [Range(1, Int32.MaxValue)]
        public int ContaId { get; }

        [Required]
        [Range(0.01, 999999999999.99)]
        public decimal Valor { get; }

        public SaqueRequestDTO(int contaId, decimal valor)
        {
            ContaId = contaId;
            Valor = valor;
        }
    }
}