using ContaBancaria.API.Data;

namespace ContaBancaria.API.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context) => _context = context;
    } 
}