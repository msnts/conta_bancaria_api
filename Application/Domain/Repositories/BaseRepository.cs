using ContaBancaria.API.Data;

namespace ContaBancaria.API.Domain.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly DataContext context;

        public BaseRepository(DataContext context) => this.context = context;
    } 
}