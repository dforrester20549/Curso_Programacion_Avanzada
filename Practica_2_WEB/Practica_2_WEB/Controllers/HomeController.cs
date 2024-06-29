using Microsoft.AspNetCore.Mvc;
using Practica_2_WEB.Interfaces;
using Practica_2_WEB.Models;
using Practica_2_WEB.Entities;
using Practica_2_WEB.Interfaces;
using System.Diagnostics;

namespace Practica_2_WEB.Controllers
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class HomeController(IVendedorModel iVendedorModel) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrarVendedor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarVendedor(Vendedor ent)
        {
            var resp = iVendedorModel.RegistrarVendedor(ent);

            if (resp.Codigo == 1)
                return RedirectToAction("Index", "Home");

            ViewBag.msj = resp.Detalle;
            return View();
        }

    }
}
