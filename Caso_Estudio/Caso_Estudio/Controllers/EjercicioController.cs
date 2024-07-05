using Caso_Estudio.Entidad;
using Caso_Estudio.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Caso_Estudio.Controllers
{
    public class EjercicioController(IEjerciciosModel iEjercicioModel) : Controller
    {


        [HttpGet]
        public IActionResult Consultar()
        {
            var respuesta = iEjercicioModel.ConsultarEjercicios();

            if (respuesta.Codigo == 1)
            {
                var datos = JsonSerializer.Deserialize<List<Ejercicios>>((JsonElement)respuesta.Contenido!);
                return View(datos);
            }

            return View(new List<Ejercicios>());
        }

        [HttpGet]
        public IActionResult RegistrarEjercicio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarEjercicio(Ejercicios entidad)
        {
            var resp = iEjercicioModel.RegistrarEjercicio(entidad);

            if (resp.Codigo == 1)
                return RedirectToAction("ConsultarVehiculos", "Vehiculo");

            ViewBag.msj = resp.Mensaje;
            return View();
        }
    }
}
