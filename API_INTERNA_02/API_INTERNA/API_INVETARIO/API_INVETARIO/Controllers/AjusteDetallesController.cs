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
    public class AjusteDetallesController : ControllerBase
    {
        private readonly Contexto _context;

        public AjusteDetallesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/AjusteDetalles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AjusteDetalle>>> GetAjusteDetalles(string? searchFor)
        {
            var datos = _context.AjusteDetalle
                .Include("Producto")
                .Include("cabecera");

            if (string.IsNullOrEmpty(searchFor))
            {
                return await datos.ToListAsync();
            }
            else
            {
                return await datos.Where(d =>
                    d.det_id.ToLower().Contains(searchFor.ToLower()) ||
                    d.det_catidad.ToString().ToLower().Contains(searchFor.ToLower()) ||
                    d.Producto.prod_id.ToLower().Contains(searchFor.ToLower()) ||
                    d.Producto.prod_nombre.ToLower().Contains(searchFor.ToLower()) ||
                    d.Producto.prod_iva.ToString().ToLower().Contains(searchFor.ToLower()) ||
                    d.Producto.prod_pvp.ToString().ToLower().Contains(searchFor.ToLower()) ||
                    d.Producto.prod_stock.ToString().ToLower().Contains(searchFor.ToLower()) ||
                    d.cabecera.cab_id.ToLower().Contains(searchFor.ToLower()) ||
                    d.cabecera.cab_doc.ToLower().Contains(searchFor.ToLower()) 
                ).ToListAsync();
            }

            return await _context.AjusteDetalle.Include("Producto").Include("cabecera").ToListAsync();
        }

        // GET: api/AjusteDetalles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AjusteDetalle>> GetAjusteDetalle(string id)
        {
            var ajusteDetalle = await _context
                .AjusteDetalle
                .Where(a => a.det_id == id)
                .Include("Producto")
                .Include("cabecera")
                .FirstOrDefaultAsync(a => a.det_id == id);



            if (ajusteDetalle == null)
            {
                return NotFound();
            }

            return ajusteDetalle;
        }

        // PUT: api/AjusteDetalles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAjusteDetalle(string id, AjusteDetalle ajusteDetalle)
        {
            if (id != ajusteDetalle.det_id)
            {
                return BadRequest();
            }

            _context.Entry(ajusteDetalle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AjusteDetalleExists(id))
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

        // POST: api/AjusteDetalles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AjusteDetalle>> PostAjusteDetalle(AjusteDetalle ajusteDetalle)
        {
            _context.AjusteDetalle.Add(ajusteDetalle);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AjusteDetalleExists(ajusteDetalle.det_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAjusteDetalle", new { id = ajusteDetalle.det_id }, ajusteDetalle);
        }

        // DELETE: api/AjusteDetalles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAjusteDetalle(string id)
        {
            var ajusteDetalle = await _context.AjusteDetalle.FindAsync(id);
            if (ajusteDetalle == null)
            {
                return NotFound();
            }

            _context.AjusteDetalle.Remove(ajusteDetalle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AjusteDetalleExists(string id)
        {
            return _context.AjusteDetalle.Any(e => e.det_id == id);
        }
    }
}
