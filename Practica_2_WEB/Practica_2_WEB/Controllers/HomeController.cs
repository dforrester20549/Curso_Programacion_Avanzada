using Microsoft.AspNetCore.Mvc;
using Practica_2_WEB.Models;
using Practica_2_WEB.Entities;
using System.Diagnostics;

namespace Practica_2_WEB.Controllers
{

    public class HomeController() : Controller
    {

        public IActionResult Index()
        { 
            return View();
        }
    }
}
