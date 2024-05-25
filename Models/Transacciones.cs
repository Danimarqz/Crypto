using System.ComponentModel.DataAnnotations.Schema;

namespace MarquezBouzoDanielExamen1.Models
{
    [Table("transacciones")]
    public class Transacciones
    {
        public int id { get; set; }
        public int usuario_id { get; set; }
        public int criptomoneda_id { get; set; }
        public int cantidad {  get; set; }
        public decimal precio_total { get; set; }
        public DateTime fecha_transaccion {  get; set; }
    }
}
