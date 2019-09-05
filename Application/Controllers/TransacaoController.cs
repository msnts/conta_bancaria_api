using System.Collections.Generic;
using System.Threading.Tasks;
using ContaBancaria.API.Domain.DTOs;
using ContaBancaria.API.Domain.Models;
using ContaBancaria.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContaBancaria.API.Controllers
{
    [Route("api/contas/{conta}")]
    [ApiController]
    public class TransacaoController : ControllerBase
    {
        private ITransacaoService transacaoService;

        public TransacaoController(ITransacaoService service) => this.transacaoService = service;

        //GET: api/transacoes/{conta}
        [HttpGet("transacoes")]
        public async Task<ActionResult<IEnumerable<Transacao>>> FindAll(int conta)
        {
            var transacoes = await this.transacaoService.FindAll(conta);

            return Ok(transacoes);
        }

        //POST: api/transacoes/{conta}/depositos
        [HttpPost("depositos")]
        public async Task<ActionResult<IContaCorrente>> PostDeposito(int conta, DepositoRequestDTO depositoRequest)
        {
            var transacao = await this.transacaoService.DepositarAsync(conta, depositoRequest.Valor);

            return Created($"api/contas/{transacao.Conta.Id}", transacao.Conta);
        }
    
        //POST: api/transacoes/{conta}/saques
        [HttpPost("saques")]
        public async Task<ActionResult<IContaCorrente>> PostSaques(int conta, SaqueRequestDTO saqueRequest)
        {
            var transacao = await this.transacaoService.SacarAsync(conta, saqueRequest.Valor);

            return Created($"api/contas/{transacao.Conta.Id}", transacao.Conta);
        }

        //POST: api/transacoes/{conta}/transferencias
        [HttpPost("transferencias")]
        public async Task<ActionResult<IContaCorrente>> PostTransferencias(int conta, TransferenciaRequestDTO transferenciaRequest)
        {
            var transacoes = await this.transacaoService.TransferirAsync(conta, transferenciaRequest.ContaDestinoId, transferenciaRequest.Valor);

            return Created($"api/contas/{conta}", transacoes.Item1.Conta);
        }
    }
}