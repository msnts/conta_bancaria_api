using System.Collections.Generic;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.Domain.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<IEnumerable<ContaCorrente>> ListAsync();

        Task<ContaCorrente> FindByIdAsync(int id);

        Task SaveAsync(ContaCorrente contaCorrente);

        Task UpdateAsync(ContaCorrente contaCorrente);

        Task DeleteAsync(ContaCorrente contaCorrente);

        bool ContaCorrenteExists(ContaCorrente contaCorrente);

    }
}