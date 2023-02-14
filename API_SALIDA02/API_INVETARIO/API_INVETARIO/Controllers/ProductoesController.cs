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
        public async Task<ActionResult<IEnumerable<Producto>>> GetProducto()
        {
            return await _context.Producto.OrderBy(x => x.prod_id).ToListAsync();
        }

        // GET: api/Productoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(string id)
        {
            var producto = await _context.Producto.FindAsync(id);

            if (producto == null)
            {
                return NotFound();
            }

            return producto;
        }


        private bool ProductoExists(string id)
        {
            return _context.Producto.Any(e => e.prod_id == id);
        }
    }
}
