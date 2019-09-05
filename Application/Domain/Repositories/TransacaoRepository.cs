using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
            return await this.context.Transacoes.Include(x => x.ContaCorrente).Where(t => t.ContaCorrenteId == conta).ToListAsync();
        }

        public async Task SaveAsync(Transacao transacao)
        {
            DoAddTransacao(transacao);

            await this.context.SaveChangesAsync();
        }

        private void DoAddTransacao(Transacao transacao)
        {
            this.context.Transacoes.Add(transacao);

            if (transacao is ITarifavel)
            {
                this.context.Transacoes.Add((Transacao)((ITarifavel)transacao).Tarifa);
            }
        }

        public async Task SaveAsync(IEnumerable<ITransacao> transacoes)
        {
            foreach (var item in transacoes)
            {
                DoAddTransacao((Transacao) item);
            }

            await this.context.SaveChangesAsync();
        }
    }
}