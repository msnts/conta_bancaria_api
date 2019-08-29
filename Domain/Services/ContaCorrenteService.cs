using ContaBancaria.API.Domain.Repositories;

namespace ContaBancaria.API.Domain.Services
{
    public class ContaCorrenteService: IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository repository) => _contaCorrenteRepository = repository;
    }
}