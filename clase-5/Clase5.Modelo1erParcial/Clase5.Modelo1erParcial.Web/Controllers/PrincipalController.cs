using Clase5.Modelo1erParcial.Logica;
using Microsoft.AspNetCore.Mvc;

namespace Clase5.Modelo1erParcial.Web.Controllers
{
    public class PrincipalController : Controller
    {
        private readonly IRectanguloService _rectanguloService;
        public PrincipalController(IRectanguloService rectanguloService)
        {
            _rectanguloService = rectanguloService;
        }
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
                _rectanguloService.Agregar(request);
                //guardo en tempdata el ultimo id para mostrarlo en negrita en la vista de resultados
                TempData["UltRectanguloAgregadoId"] = request.Id;
                return RedirectToAction("Resultados");
            }
            
            return View(request);
        }

        [HttpGet]
        public IActionResult Resultados()
        {
            return View(_rectanguloService.Listar());
        }
    }
}
