using Clase6.EF.Data.EF;
using Clase6.EF.Logica;
using Microsoft.AspNetCore.Mvc;

namespace Clase6.EF.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UbicacionController : ControllerBase
{
    private readonly IUbicacionServicio _ubicacionServicio;

    public UbicacionController(IUbicacionServicio ubicacionServicio)
    {
        this._ubicacionServicio = ubicacionServicio;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_ubicacionServicio.ObtenerTodos());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        return Ok(_ubicacionServicio.ObtenerPorId(id));
    }


    [HttpPost]
    public IActionResult Post([FromBody] Ubicacion ubicacion)
    {
        if(this._ubicacionServicio.ObtenerPorNombre(ubicacion.Nombre) != null)
            return BadRequest("Ya existe una ubicacion con ese nombre");
        _ubicacionServicio.Agregar(ubicacion);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Ubicacion ubicacion)
    {
        if(this._ubicacionServicio.ObtenerPorId(id) == null)
            return BadRequest("No existe una ubicacion con ese id");
        ubicacion.Id = id;
        _ubicacionServicio.Actualizar(ubicacion);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if(this._ubicacionServicio.ObtenerPorId(id) == null)
            return BadRequest("No existe una ubicacion con ese id");
        _ubicacionServicio.Eliminar(id);
        return Ok();
    }
}