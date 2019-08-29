using ContaBancaria.API.Data;

namespace ContaBancaria.API.Domain.Repositories
{
    public class ContaCorrenteRepository : BaseRepository, IContaCorrenteRepository
    {
        public ContaCorrenteRepository(DataContext context) : base(context)
        {
        }
    }
}