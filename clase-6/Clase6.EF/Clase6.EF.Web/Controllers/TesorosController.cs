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

    [HttpGet("{id}")]
    public Tesoro Get(int id)
    {
        return _tesoroServicio.ObtenerPorId(id);
    }

    [HttpPost]
    public void Post([FromBody] Tesoro tesoro)
    {
        _tesoroServicio.Agregar(tesoro);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Tesoro tesoro)
    {
        tesoro.Id = id;
        _tesoroServicio.Actualizar(tesoro);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _tesoroServicio.Eliminar(id);
    }
}
