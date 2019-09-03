using System.Collections.Generic;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.Domain.Repositories
{
    public interface ITransacaoRepository
    {
        Task<IEnumerable<Transacao>> FindAllAsync(int conta);
        Task SaveAsync(Transacao transacao);
    }
}