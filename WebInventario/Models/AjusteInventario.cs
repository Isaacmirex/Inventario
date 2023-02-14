namespace WebInventario.Models
{
    public class AjusteInventario
    {
        public AjusteCabecera? cabecera { get; set; }
        public List<AjusteDetalle>? detalles { get; set; }

        public AjusteInventario()
        {
            detalles = new List<AjusteDetalle>();
        }
    }
}
