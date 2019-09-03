using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.Exceptions;
using ContaBancaria.API.Domain.Models;
using ContaBancaria.API.Domain.Repositories;

namespace ContaBancaria.API.Domain.Services
{
    public class TransacaoService : ITransacaoService
    {
        private ITransacaoRepository transacaoRepository;

        private IContaCorrenteRepository contaRepository;

        public TransacaoService(ITransacaoRepository repository, IContaCorrenteRepository contaRepository) 
        {
            this.transacaoRepository = repository;
            this.contaRepository = contaRepository;
        }

        public async Task<IEnumerable<Transacao>> FindAll(int conta)
        {
            return await this.transacaoRepository.FindAllAsync(conta);
        }

        private async Task<IContaCorrente> DoFindContaAsync(int contaId)
        {
            var contaCorrente = await this.contaRepository.FindByIdAsync(contaId);

            if (contaCorrente == null)
            {
                throw new ContaCorrenteNotFoundException($"Conta corrente {contaId} não encontrada");
            }

            return await Task.FromResult(contaCorrente);
        }

        public async Task<IDeposito> DepositarAsync(int contaId, decimal valor)
        {
            var contaCorrente = await DoFindContaAsync(contaId);

            var saldoAnterior = contaCorrente.Saldo;

            contaCorrente.Creditar(valor);

            var transacao = new Deposito(contaCorrente, DateTime.Now, saldoAnterior, valor, contaCorrente.Saldo);

            transacao.CalcularTarifa();

            await this.transacaoRepository.SaveAsync(transacao);

            return transacao;
        }

        public async Task<ISaque> SacarAsync(int contaId, decimal valor)
        {
            var contaCorrente = await DoFindContaAsync(contaId);

            var saldoAnterior = contaCorrente.Saldo;

            contaCorrente.Debitar(valor);

            var transacao = new Saque(contaCorrente, DateTime.Now, saldoAnterior, valor, contaCorrente.Saldo);

            transacao.CalcularTarifa();

            await this.transacaoRepository.SaveAsync(transacao);

            return transacao;
        }

        public async Task TransferirAsync(int contaOrigemId, int contaDestinoId, decimal valor)
        {
            var contaOrigem = await DoFindContaAsync(contaOrigemId);

            var contaDestino = await DoFindContaAsync(contaDestinoId);


        }
    }
}