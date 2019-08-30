using System.Collections.Generic;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.Domain.Services
{
    public interface IContaCorrenteService
    {
        Task<IEnumerable<ContaCorrente>> ListAsync();

        Task<ContaCorrente> FindByIdAsync(int id);

        Task SaveAsync(ContaCorrente conta);

        Task UpdateAsync(ContaCorrente conta);

        Task DeleteAsync(int id);
    }
}