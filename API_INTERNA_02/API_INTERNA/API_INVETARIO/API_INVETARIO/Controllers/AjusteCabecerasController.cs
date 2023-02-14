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
    public class AjusteCabecerasController : ControllerBase
    {
        private readonly Contexto _context;

        public AjusteCabecerasController(Contexto context)
        {
            _context = context;
        }

        // GET: api/AjusteCabeceras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AjusteCabecera>>> GetAjusteCabeceras(string? searchFor)
        {
            if (string.IsNullOrEmpty(searchFor))
            {
                return await _context.AjusteCabecera.ToListAsync();
            }
            else
            {
                return await _context.AjusteCabecera.Where(c =>
                    c.cab_id.ToLower().Contains(searchFor.ToLower()) ||
                    c.cab_fecha.ToString().ToLower().Contains(searchFor.ToLower()) ||
                    c.cab_doc.ToLower().Contains(searchFor.ToLower()) ||
                    c.cab_descripcion.ToLower().Contains(searchFor.ToLower()) 
                ).ToListAsync();
            }
            return await _context.AjusteCabecera.ToListAsync();
        }

        // GET: api/AjusteCabeceras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AjusteCabecera>> GetAjusteCabecera(string id)
        {
            var ajusteCabecera = await _context.AjusteCabecera.FindAsync(id);

            if (ajusteCabecera == null)
            {
                return NotFound();
            }

            return ajusteCabecera;
        }

        // PUT: api/AjusteCabeceras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAjusteCabecera(string id, AjusteCabecera ajusteCabecera)
        {
            if (id != ajusteCabecera.cab_id)
            {
                return BadRequest();
            }

            _context.Entry(ajusteCabecera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AjusteCabeceraExists(id))
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

        // POST: api/AjusteCabeceras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AjusteCabecera>> PostAjusteCabecera(AjusteCabecera ajusteCabecera)
        {
            _context.AjusteCabecera.Add(ajusteCabecera);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AjusteCabeceraExists(ajusteCabecera.cab_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAjusteCabecera", new { id = ajusteCabecera.cab_id }, ajusteCabecera);
        }

        // DELETE: api/AjusteCabeceras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAjusteCabecera(string id)
        {
            var ajusteCabecera = await _context.AjusteCabecera.FindAsync(id);
            if (ajusteCabecera == null)
            {
                return NotFound();
            }

            _context.AjusteCabecera.Remove(ajusteCabecera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AjusteCabeceraExists(string id)
        {
            return _context.AjusteCabecera.Any(e => e.cab_id == id);
        }
    }
}
