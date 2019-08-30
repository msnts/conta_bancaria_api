using ContaBancaria.API.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Models;
using ContaBancaria.API.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace ContaBancaria.API.Domain.Services
{
    public class ContaCorrenteService: IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository repository) => _contaCorrenteRepository = repository;

        public async Task<IEnumerable<ContaCorrente>> ListAsync()
        {
            return await _contaCorrenteRepository.ListAsync();
        }

        public async Task<ContaCorrente> FindByIdAsync(int id)
        {
            var conta = await _contaCorrenteRepository.FindByIdAsync(id);

            if (conta == null) 
                throw new ContaCorrenteNotFoundException($"Conta Corrente '{id}' não encontrada");

            return conta;
        }

        public async Task SaveAsync(ContaCorrente conta)
        {
            await _contaCorrenteRepository.SaveAsync(conta);
        }

        public async Task UpdateAsync(ContaCorrente conta)
        {
            try
            {
                await _contaCorrenteRepository.UpdateAsync(conta);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_contaCorrenteRepository.ContaCorrenteExists(conta))
                {
                    throw new ContaCorrenteNotFoundException($"Conta Corrente '{conta.Id}' não encontrada");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            var contaCorrente = await _contaCorrenteRepository.FindByIdAsync(id);
            if (contaCorrente == null)
            {
                throw new ContaCorrenteNotFoundException($"Conta Corrente '{contaCorrente.Id}' não encontrada");
            }

            await _contaCorrenteRepository.DeleteAsync(contaCorrente);
        }
    }
}