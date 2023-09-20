using Clase5.Modelo1erParcial.Logica;
using Microsoft.AspNetCore.Mvc;

namespace Clase5.Modelo1erParcial.Web.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Bienvenido()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CalcularAreaRectangulo()
        {
            return View(new Rectangulo());
        }

        [HttpPost]
        public IActionResult CalcularAreaRectangulo(Rectangulo request)
        {
            if (ModelState.IsValid)
            {
                return View("Resultados");
            }
            
            return View(request);
        }

        [HttpGet]
        public IActionResult Resultados()
        {
            return View();
        }
    }
}
