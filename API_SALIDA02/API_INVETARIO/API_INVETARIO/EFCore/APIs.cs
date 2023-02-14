using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_INVETARIO.EFCore
{
    [Table("apis")]
    public class APIs
    {

        [Key, Required]
        public string apps_id { set; get; }
        public string apps_documento { set; get; }
        public string apps_doc_codigo { set; get; }
        public string apps_modificacion { set; get; }
        public DateOnly apps_fecha { set; get;  }
        public string apps_descripcion { set; get; }
        public String Productoprod_id { get; set; }
        //relations

        public Producto? Producto { set; get; }

    }
}
