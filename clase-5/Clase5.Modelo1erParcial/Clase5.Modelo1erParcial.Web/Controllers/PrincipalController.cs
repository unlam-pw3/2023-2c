using Microsoft.AspNetCore.Mvc;

namespace Clase5.Modelo1erParcial.Web.Controllers
{
    public class PrincipalController : Controller
    {
        public IActionResult Bienvenido()
        {
            return View();
        }
    }
}
