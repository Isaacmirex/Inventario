using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_INVETARIO.EFCore
{
    [Table("categoria")]
    public class Categoria
    {
        [Key,Required]
        public string cat_id { get; set; }
        public string cat_nombre { get; set; }
        public string cat_descripcion { get; set; }
    }
}
