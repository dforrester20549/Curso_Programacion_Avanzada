using Microsoft.AspNetCore.Mvc;
using Practica_2_WEB.Entities;
using Practica_2_WEB.Models;

namespace Practica_2_WEB.Controllers
{
    public class VendedorController (IVendedorModel iVendedorModel) : Controller
    {
        [HttpGet]
        public IActionResult RegistrarVendedor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarVendedor(Vendedor entidad)
        {
            var resp = iVendedorModel.RegistrarVendedor(entidad);

            if (resp.Codigo == 1)
                return RedirectToAction("Index", "Home");

            ViewBag.msj = resp.Mensaje;
            return View();
        }
    }
}
