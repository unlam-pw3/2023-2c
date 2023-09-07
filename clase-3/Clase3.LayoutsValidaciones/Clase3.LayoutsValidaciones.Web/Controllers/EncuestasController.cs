using Clase3.LayoutsValidaciones.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clase3.LayoutsValidaciones.Web.Controllers
{
    public class EncuestasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnviarRespuesta()
        {
            return View(new EncuestaViewModel());
        }

        [HttpPost]
        public IActionResult EnviarRespuesta(EncuestaViewModel request)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            return View(request);
        }
    }
}
