using System.ComponentModel.DataAnnotations.Schema;

namespace MarquezBouzoDanielExamen1.Models
{
    [Table("criptomonedas")]
    public class Criptomonedas
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string simbolo { get; set; }
    }
}
