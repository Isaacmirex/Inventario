using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebInventario.Models
{
    public class AjusteDetalle
    {
        [Key, Required]
        public string det_id { set; get; }
        public int det_catidad { set; get; }
        public string cabeceracab_id { set; get; }
        public string Productoprod_id { set; get; }
        //Entities
        public Producto? Producto { get; set; }
        public AjusteCabecera? cabecera { get; set; }
        public Historial? historial { get; set; }

        public List<Producto> listaProductos { get; set; }
    }
}
