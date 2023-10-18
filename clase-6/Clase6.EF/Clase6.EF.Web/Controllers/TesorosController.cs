using System.Net;
using Clase6.EF.Data.EF;
using Clase6.EF.Logica;
using Clase6.EF.Logica.Excepciones;
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
    public IActionResult Post([FromBody] Tesoro tesoro)
    {
        try
        {
            _tesoroServicio.Agregar(tesoro);
        }
        catch (TesorosException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            //TODO: logear excepcion
            return StatusCode(500, "Ha ocurrido un error inesperado");
        }
        
        return Ok();
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

    [HttpGet("ObtenerTodosEnUbicacion")]
    public ActionResult<List<Tesoro>> ObtenerTodosEnUbicacion(int idUbicacion)
    {
        return Ok(_tesoroServicio.ObtenerTodosEnUbicacion(idUbicacion));
    }
}
