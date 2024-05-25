using System.ComponentModel.DataAnnotations.Schema;

namespace MarquezBouzoDanielExamen1.Models
{
    [Table("carrito_compras")]
    public class Carrito
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int producto_id { get; set; }
        public int criptomoneda_id { get; set; }
        public int cantidad {  get; set; }
        public decimal precio_total {  get; set; }
        public DateTime fecha_compra {  get; set; }
    }
}
