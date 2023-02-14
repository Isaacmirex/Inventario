using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace WebInventario.Models
{
    public class Producto
    {
        [Key, Required]
        public String prod_id { get; set; }
        [Required(ErrorMessage = "El Nombre del Producto es requerido.")]
        public String prod_nombre { get; set; }
        [Required(ErrorMessage = "Descripción del Producto es requerido.")]
        public String prod_descripcion { get; set; }
        
        public bool prod_iva { get; set; }
        [Required(ErrorMessage = "Costo es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor a 0.")]
        public string prod_costo { get; set; }
        [Required(ErrorMessage = "Precio de venta es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El costo debe ser mayor a 0.")]
        public string prod_pvp { get; set; }

        public bool prod_estado { get; set; }       
        public int prod_stock { get; set; }
        [Required(ErrorMessage = "Categoría es requerido.")]
        public String Categoriacat_id { set; get; }

        public Categoria? Categoria { get; set; }

    }
}
