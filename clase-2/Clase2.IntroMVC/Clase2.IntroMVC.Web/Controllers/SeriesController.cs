using Clase2.IntroMvc.Logica;
using Clase2.IntroMVC.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Clase2.IntroMVC.Web.Controllers;

public class SeriesController : Controller
{
    private ISeriesRepositorio _seriesRepositorio;
    public SeriesController(ISeriesRepositorio seriesRepositorio)
    {
        _seriesRepositorio = seriesRepositorio;
    }

    public IActionResult Agregar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Agregar(Serie serie)
    {
        int cantTemporadas = int.Parse(string.IsNullOrEmpty(Request.Form["CantidadDeTemporadas"]) ? "0" : Request.Form["CantidadDeTemporadas"]);

        serie.EstaEnStarPlus = Request.Form["EstaEnStarPlus"] == "on"; 
        serie.EstaEnNetflix = Request.Form["EstaEnNetflix"] == "on"; 
        serie.EstaEnHBO = Request.Form["EstaEnHBO"] == "on"; 
        serie.EstaEnDisney = Request.Form["EstaEnDisney"] == "on"; 
        serie.EstaEnAmazon = Request.Form["EstaEnAmazon"] == "on"; 
        _seriesRepositorio.Agregar(serie, cantTemporadas);
        return RedirectToAction("Listado");
    }
    public IActionResult Listado()
    {
        var series = _seriesRepositorio.ObtenerTodas();
        return View(series);
    }
}
