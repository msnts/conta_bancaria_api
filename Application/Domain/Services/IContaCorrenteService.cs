using System.Collections.Generic;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.Domain.Services
{
    public interface IContaCorrenteService
    {
        Task<IEnumerable<ContaCorrente>> ListAsync();

        Task<IContaCorrente> FindByIdAsync(int id);

        Task SaveAsync(IContaCorrente conta);

        Task UpdateAsync(IContaCorrente conta);

        Task DeleteAsync(int id);
    }
}