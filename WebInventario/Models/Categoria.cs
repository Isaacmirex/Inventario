using System.ComponentModel.DataAnnotations;

namespace WebInventario.Models
{
    public class Categoria
    {
        [Key, Required]
        public string cat_id { get; set; }
        [Required(ErrorMessage = "El Nombre de la Categoría es requerido.")]
        public string cat_nombre { get; set; }
        [Required(ErrorMessage = "Descripción es requerido.")]
        public string cat_descripcion { get; set; }

        public List<Producto>? Productos { get; set; }
    }
}
