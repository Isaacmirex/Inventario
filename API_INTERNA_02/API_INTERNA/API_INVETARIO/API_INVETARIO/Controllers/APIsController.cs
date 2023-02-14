using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_INVETARIO.EFCore;

namespace API_INTERNA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIsController : ControllerBase
    {
        private readonly Contexto _context;

        public APIsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/APIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<APIs>>> GetAPIs()
        {
            return await _context.APIs.Include("Producto").ToListAsync();
        }

        // GET: api/APIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<APIs>> GetAPIs(string id)
        {
            var aPIs = await _context
                .APIs
                .Where(p => p.apps_id == id)
                .Include("Producto")
                .FirstOrDefaultAsync(x => x.apps_id == id);

            if (aPIs == null)
            {
                return NotFound();
            }

            return aPIs;
        }

        // PUT: api/APIs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAPIs(string id, APIs aPIs)
        {
            if (id != aPIs.apps_id)
            {
                return BadRequest();
            }

            _context.Entry(aPIs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!APIsExists(id))
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

        // POST: api/APIs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<APIs>> PostAPIs(APIs aPIs)
        {
            _context.APIs.Add(aPIs);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (APIsExists(aPIs.apps_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAPIs", new { id = aPIs.apps_id }, aPIs);
        }

        // DELETE: api/APIs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAPIs(string id)
        {
            var aPIs = await _context.APIs.FindAsync(id);
            if (aPIs == null)
            {
                return NotFound();
            }

            _context.APIs.Remove(aPIs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool APIsExists(string id)
        {
            return _context.APIs.Any(e => e.apps_id == id);
        }
    }
}
