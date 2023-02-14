using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_INVETARIO.EFCore
{
    [Table("producto")]
    public class Producto
    {


        [Key, Required]
        public String prod_id { get; set; }
        public String prod_nombre { get; set; }
        public String prod_descripcion { get; set; }
        public bool prod_iva { get; set; }
        public string prod_costo { get; set; }
        public string prod_pvp { get; set; }
        public bool prod_estado { get; set; }
        public int prod_stock { get; set; }
        public String Categoriacat_id { set; get; }
        ////relations 

        public Categoria? Categoria { get; set; }
        //public List<AjusteDetalle>? AjusteDetalle{get;set;}
        //public List<AjusteCabecera>? AjusteCabecera { get; set; }
        //public List<APIs>? APIs { get; set; }


    }
}
