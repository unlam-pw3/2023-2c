using Clase7.Modelo2doParcial.Data.EF;
using Clase7.Modelo2doParcial.Logica;
using Microsoft.AspNetCore.Mvc;

namespace Clase7.Modelo2doParcial.Web.Controllers;

public class SucursalesController : Controller
{
    private ISucursalesServicio _sucursalesServicio;
    private ICadenasServicio _cadenasServicio;

    public SucursalesController(ISucursalesServicio sucursalesServicio, ICadenasServicio cadenasServicio)
    {
        _sucursalesServicio = sucursalesServicio;
        _cadenasServicio = cadenasServicio;
    }
    public IActionResult Listar(int? IdCadena)
    {
        AgregarCadenasAlViewBag(IdCadena);
        if (IdCadena.HasValue)
        {
            return View(_sucursalesServicio.Filtrar(IdCadena));
        }
        else
        {
            return View(_sucursalesServicio.Listar());
        }
    }

    public IActionResult Crear()
    {
        AgregarCadenasAlViewBag(null);

        return View(new Sucursal());
    }


    [HttpPost]
    public IActionResult Crear(Sucursal sucursal)
    {
        if (!ModelState.IsValid)
        {
            AgregarCadenasAlViewBag(sucursal.IdCadena);
            return View(sucursal);
        }

        _sucursalesServicio.Crear(sucursal);

        return RedirectToAction("Listar");
    }

    public IActionResult Eliminar(int id)
    {
        _sucursalesServicio.Eliminar(id);
        return RedirectToAction("Listar");
    }

    private void AgregarCadenasAlViewBag(int? idCadenaSeleccionada)
    {
        var cadenas = _cadenasServicio.Listar();
        
        ViewBag.IdCadenaSeleccionada = idCadenaSeleccionada;
        ViewBag.Cadenas = cadenas;
    }
}
