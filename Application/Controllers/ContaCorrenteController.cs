using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContaBancaria.API.Data;
using ContaBancaria.API.Domain.Models;
using ContaBancaria.API.Domain.Services;

namespace ContaBancaria.API.Controllers
{
    [Route("api/contas")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteService _contaCorrenteService;

        public ContaCorrenteController(IContaCorrenteService service)
        {
            _contaCorrenteService = service;
        }

        // GET: api/contas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaCorrente>>> GetContas()
        {
            var result = await _contaCorrenteService.ListAsync();

            return Ok(result);
        }

        // GET: api/contas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaCorrente>> GetContaCorrente(int id)
        {
            var contaCorrente = await _contaCorrenteService.FindByIdAsync(id);

            return (ContaCorrente) contaCorrente;
        }

        // PUT: api/contas/5
        [HttpPut("{id}")]
        public async Task<ActionResult<IContaCorrente>> PutContaCorrente(int id, ContaCorrente contaCorrente)
        {
            if (id != contaCorrente.Id)
            {
                return BadRequest();
            }

            await _contaCorrenteService.UpdateAsync(contaCorrente);

            return Ok(contaCorrente);
        }

        // POST: api/contas
        [HttpPost]
        public async Task<ActionResult<IContaCorrente>> PostContaCorrente(ContaCorrente contaCorrente)
        {
            await _contaCorrenteService.SaveAsync(contaCorrente);

            return CreatedAtAction("GetContaCorrente", new { id = contaCorrente.Id }, contaCorrente);
        }

        // DELETE: api/contas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContaCorrente(int id)
        {
            await _contaCorrenteService.DeleteAsync(id);

            return NoContent();
        }
    }
}
