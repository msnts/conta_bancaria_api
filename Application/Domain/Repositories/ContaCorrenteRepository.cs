using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ContaBancaria.API.Data;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.Domain.Repositories
{
    public class ContaCorrenteRepository : BaseRepository, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ContaCorrente>> ListAsync()
        {
            return await this.context.Contas.ToListAsync();
        }

        public async Task<IContaCorrente> FindByIdAsync(int id)
        {
            return await this.context.Contas.FindAsync(id);
        }

        public async Task SaveAsync(IContaCorrente contaCorrente)
        {
            this.context.Contas.Add((ContaCorrente) contaCorrente);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IContaCorrente contaCorrente)
        {
            this.context.Entry(contaCorrente).State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteAsync(IContaCorrente contaCorrente)
        {
            this.context.Contas.Remove((ContaCorrente) contaCorrente);
            await this.context.SaveChangesAsync();
        }

        public bool ContaCorrenteExists(IContaCorrente contaCorrente)
        {
            return this.context.Contas.Any(e => e.Id == contaCorrente.Id);
        }
    }
}