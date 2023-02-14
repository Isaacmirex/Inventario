using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebInventario.Models
{
    public class AjusteCabecera
    {
        [Key, Required]
        public string cab_id { get; set; }
        public DateTime? cab_fecha { get; set; }
        public string cab_doc { get; set; }
        public string cab_descripcion { get; set; }
        public List<AjusteDetalle> AjusteDetalles { get; internal set; }
    }
}
