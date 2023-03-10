using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_INTERNA.EFCore
{

    [Table("historial")]
    public class Historial
    {
        [Key, Required]
        public string historial_id { get; set; }
        public DateTime historial_fecha { get; set; }
        public string historial_documento { get; set; }
        public string historial_cab_descripcion { get; set; }
        public string historial_descripcion { get; set;  }
        public int historial_cantidad { get; set;  }
        public int historial_stock { get; set; }
        public string historial_nombreprod { get; set; }
        
    }
}
