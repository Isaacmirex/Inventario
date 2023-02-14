using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_INVETARIO.EFCore
{
    [Table("ajustecabecera")]
    public class AjusteCabecera
    {
      

        [Key,Required]
        public string cab_id { get; set; }
        public string cab_descripcion { get; set; }
        public DateTime cab_fecha { get; set; }
        public string productoprod_id { get; set; }
        //relations
        public Producto? producto { get; set; }
        public List<AjusteDetalle>? AjusteDetalle { set; get; }

    }
}
