using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ContaBancaria.API.Data;
using ContaBancaria.API.Domain.Models;

namespace ContaBancaria.API.Domain.Repositories
{
    public class TransacaoRepository : BaseRepository, ITransacaoRepository
    {
        public TransacaoRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Transacao>> FindAllAsync(int conta)
        {
            return await _context.Transacoes.Include(x => x.ContaCorrente).Where(t => t.ContaCorrenteId == conta).ToListAsync();
        }

        public async Task SaveAsync(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
            _context.Entry(transacao.Conta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}