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
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly IContaCorrenteService _contaCorrenteService;

        public ContaCorrenteController(IContaCorrenteService service)
        {
            _contaCorrenteService = service;
        }

        // GET: api/ContaCorrente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaCorrente>>> GetContas()
        {
            var result = await _contaCorrenteService.ListAsync();

            return Ok(result);
        }

        // GET: api/ContaCorrente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContaCorrente>> GetContaCorrente(int id)
        {
            var contaCorrente = await _contaCorrenteService.FindByIdAsync(id);

            return (ContaCorrente) contaCorrente;
        }

        // PUT: api/ContaCorrente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContaCorrente(int id, IContaCorrente contaCorrente)
        {
            if (id != contaCorrente.Id)
            {
                return BadRequest();
            }

            await _contaCorrenteService.UpdateAsync(contaCorrente);

            return NoContent();
        }

        // POST: api/ContaCorrente
        [HttpPost]
        public async Task<ActionResult<IContaCorrente>> PostContaCorrente(IContaCorrente contaCorrente)
        {
            await _contaCorrenteService.SaveAsync(contaCorrente);

            return CreatedAtAction("GetContaCorrente", new { id = contaCorrente.Id }, contaCorrente);
        }

        // DELETE: api/ContaCorrente/5
        [HttpDelete("{id}")]
        public async Task DeleteContaCorrente(int id)
        {
            await _contaCorrenteService.DeleteAsync(id);
        }
    }
}
