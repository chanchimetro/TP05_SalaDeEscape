using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TP05_SalaDeEscape.Models;

namespace TP05_SalaDeEscape.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Tutorial()
        {
            return View();
        }

        public IActionResult Comenzar() //Comenzar la proxima habitacion
        {
            if(Escape.EstadoJuego == 0) Escape.InicialiazarJuego();
            return View(Escape.nombreViews[Escape.EstadoJuego+1]);
        }

        [HttpPost]
        public IActionResult Habitacion(int sala, string clave)
        {
            if(sala != Escape.EstadoJuego) return View(Escape.nombreViews[Escape.EstadoJuego]);
            if(Escape.resolverSala(sala, clave)) return Comenzar();
            ViewBag.Error = "La respuesta es incorrecta!";
            return View(Escape.nombreViews[Escape.EstadoJuego]); //Tambien es posible utilizar Habitacion[sala]
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
