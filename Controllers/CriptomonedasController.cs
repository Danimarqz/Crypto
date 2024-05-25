using MarquezBouzoDanielExamen1.Models;
using MarquezBouzoDanielExamen1.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace MarquezBouzoDanielExamen1.Controllers
{
    public class CriptomonedasController : Controller
    {
        private readonly ICriptomonedasRepository _criptomonedasRepository;
        public CriptomonedasController(ICriptomonedasRepository criptomonedasRepository)
        {
            _criptomonedasRepository = criptomonedasRepository;
        }
        // GET: CriptomonedasController
        public async Task<ActionResult> IndexAsync()
        {
            if (CheckLogin())
            {
                var data = await _criptomonedasRepository.GetAll();
            return View("Index", data);
            }
            return View(GlobalVar.LoginView);
        }

        // GET: CriptomonedasController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (CheckLogin())
            {
                var data = await _criptomonedasRepository.GetById(id);
            return View("Edit", data);
            }
            return View(GlobalVar.LoginView);
        }

        // GET: CriptomonedasController/Create
        public async Task<ActionResult> Create(int id)
        {
            if (CheckLogin())
            {
                var data = await _criptomonedasRepository.GetById(id);
            return View("Create", data);
                }
                return View(GlobalVar.LoginView);
            }

        // POST: CriptomonedasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Criptomonedas criptomonedas)
        {
            if (CheckLogin())
            {
                _criptomonedasRepository.Save(criptomonedas);
                var data = await _criptomonedasRepository.GetAll();
                return View("Index",data);
            }
                return View(GlobalVar.LoginView);
        }

        // POST: CriptomonedasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditFAsync(Criptomonedas c)
        {
            if (CheckLogin()) { 
                await _criptomonedasRepository.Edit(c);
            return RedirectToAction("Index");
            }
            return View(GlobalVar.LoginView);

        }

        // GET: CriptomonedasController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (CheckLogin())
            {

            var data = await _criptomonedasRepository.GetById(id);
            return View("Delete", data);
            }
            return RedirectToAction("Index");
        }

        // POST: CriptomonedasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Criptomonedas c)
        {
            try
            {
                _criptomonedasRepository.Delete(c);
                var data = await _criptomonedasRepository.GetAll();
                return View("Index", data);
            }
            catch
            {
                return View();
            }
        }
        public async Task Carrito(int id)
        {
            var cripto = await _criptomonedasRepository.GetById(id);

            if (HttpContext.Session.GetString("Cartera") != null)
            {
                string arrayBytes = HttpContext.Session.GetString("Cartera");
                var cartera = JsonSerializer.Deserialize<List<Criptomonedas>>(arrayBytes);
                cartera.Add(cripto);
            } else
            {
                var cartera = new List<Criptomonedas>();
                cartera.Add(cripto);
                string jsonString = JsonSerializer.Serialize(cartera);
                HttpContext.Session.SetString("Cartera", jsonString);
            }
        }
        public bool CheckLogin()
        {
            return HttpContext.Session.GetString("Logeado") == null ? false : true;
        }
    }
}
