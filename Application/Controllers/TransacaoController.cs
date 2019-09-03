using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task PostDeposito(int conta)
        {
            await this.transacaoService.DepositarAsync(conta, 10);
        }
    
        //POST: api/transacoes/{conta}/saques
        [HttpPost("saques")]
        public async Task PostSaques(int conta)
        {
            await this.transacaoService.SacarAsync(conta, 100);
        }

        //POST: api/transacoes/{conta}/transferencias
        [HttpPost("transferencias")]
        public async Task PostTransferencias(int conta)
        {

        }
    }
}