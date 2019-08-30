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
            return await _context.Contas.ToListAsync();
        }

        public async Task<ContaCorrente> FindByIdAsync(int id)
        {
            return await _context.Contas.FindAsync(id);
        }

        public async Task SaveAsync(ContaCorrente contaCorrente)
        {
            _context.Contas.Add(contaCorrente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContaCorrente contaCorrente)
        {
            _context.Entry(contaCorrente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ContaCorrente contaCorrente)
        {
            _context.Contas.Remove(contaCorrente);
            await _context.SaveChangesAsync();
        }

        public bool ContaCorrenteExists(ContaCorrente contaCorrente)
        {
            return _context.Contas.Any(e => e.Id == contaCorrente.Id);
        }
    }
}