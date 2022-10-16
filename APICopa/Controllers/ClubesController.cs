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
    public class ClubesController : ControllerBase
    {
        private readonly ProjetoCopaContext _context;

        public ClubesController(ProjetoCopaContext context)
        {
            _context = context;
        }

        // GET: api/Clubes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clube>>> GetClubes()
        {
            return await _context.Clubes.ToListAsync();
        }

        // GET: api/Clubes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clube>> GetClube(int id)
        {
            var clube = await _context.Clubes.FindAsync(id);

            if (clube == null)
            {
                return NotFound();
            }

            return clube;
        }

        // PUT: api/Clubes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClube(int id, Clube clube)
        {
            if (id != clube.IdClube)
            {
                return BadRequest();
            }

            _context.Entry(clube).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClubeExists(id))
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

        // POST: api/Clubes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clube>> PostClube(Clube clube)
        {
            _context.Clubes.Add(clube);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClube", new { id = clube.IdClube }, clube);
        }

        // DELETE: api/Clubes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClube(int id)
        {
            var clube = await _context.Clubes.FindAsync(id);
            if (clube == null)
            {
                return NotFound();
            }

            _context.Clubes.Remove(clube);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClubeExists(int id)
        {
            return _context.Clubes.Any(e => e.IdClube == id);
        }
    }
}
