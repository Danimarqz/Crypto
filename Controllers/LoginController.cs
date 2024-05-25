using Dapper;
using MarquezBouzoDanielExamen1.Models;
using MarquezBouzoDanielExamen1.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MarquezBouzoDanielExamen1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuariosRepository _usuariosRepository;
        public LoginController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }
        // GET: LoginController
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Usuarios u)
        {
            var usuarioLogeado = await _usuariosRepository.LoginAsync(u);
            string jsonString = JsonSerializer.Serialize(usuarioLogeado);
            HttpContext.Session.SetString("Logeado", jsonString);
            GlobalVar.loggedUser = usuarioLogeado;
            return RedirectToAction("Index","Home");
        }

        // GET: LoginController/Create
        public ActionResult Registro()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(Usuarios u)
        {
            _usuariosRepository.Register(u);
            return RedirectToAction("Login");
        }
        public IActionResult Logout()
        {
            GlobalVar.loggedUser = null;
            HttpContext.Session.Clear();

            return RedirectToAction("Login");
        }




    }
}
