using System.Diagnostics;
using Clase7.Modelo2doParcial.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clase7.Modelo2doParcial.Web.Controllers
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

    }
}