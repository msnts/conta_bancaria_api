using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.Domain.Services
{
    public interface ITransacaoService
    {
        Task<IEnumerable<ITransacao>> FindAll(int conta);
        Task<IDeposito> DepositarAsync(int contaId, decimal valor);
        Task<ISaque> SacarAsync(int contaId, decimal valor);
        Task<Tuple<IDebitoTransferencia, ICreditoTransferencia>> TransferirAsync(int contaOrigemId, int contaDestinoId, decimal valor);
    }
}