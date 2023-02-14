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
    public class ProductoesController : ControllerBase
    {
        private readonly Contexto _context;

        public ProductoesController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos(string? searchfor)
        {
            var datos = _context.Producto.Include("Categoria");

            if (string.IsNullOrEmpty(searchfor))
            {
                return await datos.ToListAsync();
            }
            else
            {
                return await datos.Where(p =>
                    p.prod_id.ToLower().Contains(searchfor.ToLower()) ||
                    p.prod_nombre.ToLower().Contains(searchfor.ToLower()) ||
                    p.prod_descripcion.ToLower().Contains(searchfor.ToLower()) ||
                    p.prod_costo.ToString().ToLower().Contains(searchfor.ToLower()) ||
                    p.prod_pvp.ToString().ToLower().Contains(searchfor.ToLower()) ||
                    p.prod_stock.ToString().ToLower().Contains(searchfor.ToLower()) ||
                    p.Categoria.cat_nombre.ToLower().Contains(searchfor.ToLower()) ||
                    p.Categoria.cat_id.ToLower().Contains(searchfor.ToLower())
                ).ToListAsync();
            }

            return await _context.Producto.Include("Categoria").ToListAsync();
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(string id)
        {
            var producto = await _context
                .Producto
                .Where(p => p.prod_id == id)
                .Include("Categoria")
                .FirstOrDefaultAsync(x => x.prod_id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }

        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(string id, Producto producto)
        {
            if (id != producto.prod_id)
            {
                return BadRequest();
            }

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Producto.Add(producto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ProductoExists(producto.prod_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProducto", new { id = producto.prod_id }, producto);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(string id)
        {
            var producto = await _context.Producto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Producto.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductoExists(string id)
        {
            return _context.Producto.Any(e => e.prod_id == id);
        }
    }
}
