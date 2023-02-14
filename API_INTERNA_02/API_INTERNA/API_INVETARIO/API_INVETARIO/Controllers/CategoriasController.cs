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
    public class CategoriasController : ControllerBase
    {
        private readonly Contexto _context;

        public CategoriasController(Contexto context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias(string? searchFor)
        {
            if (string.IsNullOrEmpty(searchFor))
            {
                return await _context.Categoria.ToListAsync();
            }
            else
            {
                return await _context.Categoria.Where(c =>
                    c.cat_id.ToLower().Contains(searchFor.ToLower()) ||
                    c.cat_nombre.ToLower().Contains(searchFor.ToLower()) ||
                    c.cat_descripcion.ToLower().Contains(searchFor.ToLower())
                ).ToListAsync();
            }
            return await _context.Categoria.ToListAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(string id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(string id, Categoria categoria)
        {
            if (id != categoria.cat_id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoriaExists(categoria.cat_id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategoria", new { id = categoria.cat_id }, categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(string id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(string id)
        {
            return _context.Categoria.Any(e => e.cat_id == id);
        }
    }
}
