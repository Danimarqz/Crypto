using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarquezBouzoDanielExamen1.Models
{
    [Table("usuarios")]
    public class Usuarios
    {
        public int id { get; set; }
        public string nombre { get; set; }
        [Key]
        public string correo_electronico { get; set; }
        public string contrasena { get; set; }
        public int es_administrador { get; set; }
        //admin = 1
    }
}
