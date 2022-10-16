using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoCopa.Data;
using ProjetoCopa.Models;

namespace APICopa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaseCampeonatoesController : ControllerBase
    {
        private readonly ProjetoCopaContext _context;

        public FaseCampeonatoesController(ProjetoCopaContext context)
        {
            _context = context;
        }

        // GET: api/FaseCampeonatoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FaseCampeonato>>> GetFaseCampeonatos()
        {
            return await _context.FaseCampeonatos.ToListAsync();
        }

        // GET: api/FaseCampeonatoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FaseCampeonato>> GetFaseCampeonato(int id)
        {
            var faseCampeonato = await _context.FaseCampeonatos.FindAsync(id);

            if (faseCampeonato == null)
            {
                return NotFound();
            }

            return faseCampeonato;
        }

        // PUT: api/FaseCampeonatoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFaseCampeonato(int id, FaseCampeonato faseCampeonato)
        {
            if (id != faseCampeonato.IdFase)
            {
                return BadRequest();
            }

            _context.Entry(faseCampeonato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FaseCampeonatoExists(id))
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

        // POST: api/FaseCampeonatoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FaseCampeonato>> PostFaseCampeonato(FaseCampeonato faseCampeonato)
        {
            _context.FaseCampeonatos.Add(faseCampeonato);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFaseCampeonato", new { id = faseCampeonato.IdFase }, faseCampeonato);
        }

        // DELETE: api/FaseCampeonatoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFaseCampeonato(int id)
        {
            var faseCampeonato = await _context.FaseCampeonatos.FindAsync(id);
            if (faseCampeonato == null)
            {
                return NotFound();
            }

            _context.FaseCampeonatos.Remove(faseCampeonato);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FaseCampeonatoExists(int id)
        {
            return _context.FaseCampeonatos.Any(e => e.IdFase == id);
        }
    }
}
