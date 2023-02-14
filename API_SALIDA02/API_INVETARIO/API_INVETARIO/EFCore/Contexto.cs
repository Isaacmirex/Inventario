using Microsoft.EntityFrameworkCore;

namespace API_INVETARIO.EFCore
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        public DbSet<AjusteCabecera> AjusteCabecera { get; set; }
        public DbSet<AjusteDetalle> AjusteDetalle { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<APIs> APIs { get; set; }
    }
}
