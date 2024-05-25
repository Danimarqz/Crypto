using MarquezBouzoDanielExamen1.Models;

namespace MarquezBouzoDanielExamen1
{
    public class GlobalVar
    {
        public static Usuarios loggedUser { get; set; }
        public static bool IsLogged { get { return loggedUser != null; } }
        public static string LoginView = "/Views/Login/Login.cshtml";
    }
}
