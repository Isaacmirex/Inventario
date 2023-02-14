using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_INVETARIO.EFCore
{
    [Table("ajustecabecera")]
    public class AjusteCabecera
    {
      

        [Key,Required]
        public string cab_id { get; set; }
        public string cab_doc { get; set; }
        public string cab_descripcion { get; set; }
        public DateTime cab_fecha { get; set; }
        //relations
        //public  AjusteDetalle? ajusteDetalle { set; get; }

    }
}
