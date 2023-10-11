using Clase6.EF.Data.EF;
using Clase6.EF.Logica;
using Microsoft.AspNetCore.Mvc;

namespace Clase6.EF.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TesorosController : ControllerBase
{
    private ITesoroServicio _tesoroServicio;

    public TesorosController(ITesoroServicio tesoroServicio)
    {
        this._tesoroServicio = tesoroServicio;
    }


    [HttpGet]
    public List<Tesoro> Get()
    {
        return _tesoroServicio.ObtenerTodos();
    }
}
