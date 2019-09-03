using System.Collections.Generic;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.Domain.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<IEnumerable<ContaCorrente>> ListAsync();

        Task<IContaCorrente> FindByIdAsync(int id);

        Task SaveAsync(IContaCorrente contaCorrente);

        Task UpdateAsync(IContaCorrente contaCorrente);

        Task DeleteAsync(IContaCorrente contaCorrente);

        bool ContaCorrenteExists(IContaCorrente contaCorrente);

    }
}