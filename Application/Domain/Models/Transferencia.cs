using System.ComponentModel.DataAnnotations.Schema;

namespace ContaBancaria.API.Domain.Models
{
    [Table("transferencias")]
    public class Transferencia: ITransferencia
    {
        public Transacao Origem { get; set; }

        public Transacao Destino { get; set; }
    }
}