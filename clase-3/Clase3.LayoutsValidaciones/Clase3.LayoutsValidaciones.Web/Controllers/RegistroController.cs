using Clase3.LayoutsValidaciones.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clase3.LayoutsValidaciones.Web.Controllers
{
    public class RegistroController : Controller
    {
        private static string Layout = null;

        public IActionResult Index()
        {
            ViewData["Layout"] = RegistroController.Layout;
            return View();
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            ViewData["Layout"] = RegistroController.Layout;
            return View(new RegistroViewModel());
        }

        [HttpPost]
        public IActionResult Registrar(RegistroViewModel request)
        {
            if (ModelState.IsValid)
            {
                if(!request.Layout.Equals("---")){
                    RegistroController.Layout = request.Layout;
                }
                return RedirectToAction("Index");
            }
            ViewData["Layout"] = RegistroController.Layout;
            return View(request);
        }
    }
}