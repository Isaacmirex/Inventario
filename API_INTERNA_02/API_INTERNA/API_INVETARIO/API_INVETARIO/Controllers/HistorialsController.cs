using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_INTERNA.EFCore;
using API_INVETARIO.EFCore;

namespace API_INTERNA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialsController : ControllerBase
    {
        private readonly Contexto _context;

        public HistorialsController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Historials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Historial>>> GetHistorial()
        {
            return await _context.Historial.ToListAsync();
        }

        // GET: api/Historials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Historial>> GetHistorial(string id)
        {
            var historial = await _context.Historial.FindAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            return historial;
        }

        // PUT: api/Historials/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorial(string id, Historial historial)
        {
            if (id != historial.historial_id)
            {
                return BadRequest();
            }

            _context.Entry(historial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialExists(id))
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

        // POST: api/Historials
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Historial>> PostHistorial(Historial historial)
        {
            _context.Historial.Add(historial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HistorialExists(historial.historial_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHistorial", new { id = historial.historial_id }, historial);
        }

        // DELETE: api/Historials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorial(string id)
        {
            var historial = await _context.Historial.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }

            _context.Historial.Remove(historial);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialExists(string id)
        {
            return _context.Historial.Any(e => e.historial_id == id);
        }
    }
}
