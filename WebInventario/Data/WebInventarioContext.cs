using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebInventario.Models;

namespace WebInventario.Data
{
    public class WebInventarioContext : DbContext
    {
        public WebInventarioContext (DbContextOptions<WebInventarioContext> options)
            : base(options)
        {
        }

        public DbSet<WebInventario.Models.Producto> Producto { get; set; } = default!;

        public DbSet<WebInventario.Models.Categoria> Categoria { get; set; }

        public DbSet<WebInventario.Models.AjusteCabecera> AjusteCabecera { get; set; }

        public DbSet<WebInventario.Models.AjusteDetalle> AjusteDetalle { get; set; }

        public DbSet<WebInventario.Models.Historial> Historial { get; set; }
    }
}
