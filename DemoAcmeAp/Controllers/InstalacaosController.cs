using DemoAcmeAp.Data;
using DemoAcmeAp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAcmeAp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstalacaosController : ControllerBase
    {
        private readonly DemoAcmeApContext _context;

        public InstalacaosController(DemoAcmeApContext context)
        {
            _context = context;
        }

        // GET: api/Instalacaos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instalacao>>> GetInstalacao()
        {
            return await _context.Instalacao.ToListAsync();
        }

        // GET: api/Instalacaos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instalacao>> GetInstalacao(long id)
        {
            Instalacao instalacao = await _context.Instalacao.FindAsync(id);

            if (instalacao == null)
            {
                return NotFound();
            }

            return instalacao;
        }

        // PUT: api/Instalacaos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstalacao(long id, Instalacao instalacao)
        {
            if (id != instalacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(instalacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstalacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Instalacaos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instalacao>> PostInstalacao(Instalacao instalacao)
        {
            _context.Instalacao.Add(instalacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstalacao", new { id = instalacao.Id }, instalacao);
        }

        // DELETE: api/Instalacaos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstalacao(long id)
        {
            Instalacao instalacao = await _context.Instalacao.FindAsync(id);
            if (instalacao == null)
            {
                return NotFound();
            }

            _context.Instalacao.Remove(instalacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstalacaoExists(long id)
        {
            return _context.Instalacao.Any(e => e.Id == id);
        }
    }
}
