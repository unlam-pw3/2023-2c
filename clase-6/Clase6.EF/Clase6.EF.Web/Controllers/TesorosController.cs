using Clase6.EF.Data.EF;
using Clase6.EF.Logica;
using Clase6.EF.Logica.Excepciones;
using Clase6.EF.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clase6.EF.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class TesorosController : ControllerBase
{
    private ITesoroServicio _tesoroServicio;
    private readonly IUbicacionServicio _ubicacionServicio;

    public TesorosController(ITesoroServicio tesoroServicio, IUbicacionServicio ubicacionServicio)
    {
        this._tesoroServicio = tesoroServicio;
        this._ubicacionServicio = ubicacionServicio;
    }


    [HttpGet]
    public List<Tesoro> Get()
    {
        return _tesoroServicio.ObtenerTodos();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var tesoro = _tesoroServicio.ObtenerPorId(id);

        var response = new TesoroResponseModel
        {
            Id = tesoro.Id,
            ImagenRuta = tesoro.ImagenRuta,
            Nombre = tesoro.Nombre,
            Ubicacion = tesoro.IdUbicacionNavigation?.Id == null ? null : new UbicacionResponseModel { Id = tesoro.IdUbicacionNavigation.Id, Nombre = tesoro.IdUbicacionNavigation.Nombre }
        };

        return Ok(response);
    }

    [HttpPost]
    public IActionResult Post([FromBody] TesoroRequestModel tesoroRequest)
    {
        var tesoro = new Tesoro();
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            tesoro.Nombre = tesoroRequest.Nombre;
            tesoro.ImagenRuta = tesoroRequest.ImagenRuta;
            tesoro.IdUbicacion = tesoroRequest.IdUbicacion;

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
        
        Ubicacion ubicacion = null;
        if (tesoroRequest.IdUbicacion.HasValue)
        {
            ubicacion = _ubicacionServicio.ObtenerPorId(tesoro.IdUbicacion.Value);
        }
        
        var response = new TesoroResponseModel
        {
            Id = tesoro.Id,
            ImagenRuta = tesoro.ImagenRuta,
            Nombre = tesoro.Nombre,
            Ubicacion = ubicacion == null ? null : new UbicacionResponseModel { Id = ubicacion.Id, Nombre = ubicacion.Nombre }
        };


        return Ok(response);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] TesoroRequestModel tesoroRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var tesoro = new Tesoro
        {
            Id = tesoroRequest.Id,
            Nombre = tesoroRequest.Nombre,
            ImagenRuta = tesoroRequest.ImagenRuta,
            IdUbicacion = tesoroRequest.IdUbicacion
        };

        _tesoroServicio.Actualizar(tesoro);

        Ubicacion? ubicacion = null;
        if (tesoroRequest.IdUbicacion.HasValue)
        {
            if (tesoro.IdUbicacion.HasValue)
            {
                ubicacion = _ubicacionServicio.ObtenerPorId(tesoro.IdUbicacion.Value);
            }
        }

        var response = new TesoroResponseModel
        {
            Id = tesoro.Id,
            ImagenRuta = tesoro.ImagenRuta,
            Nombre = tesoro.Nombre,
            Ubicacion = ubicacion == null ? null : new UbicacionResponseModel { Id = ubicacion.Id, Nombre = ubicacion.Nombre }
        };
        
        return Ok(response);
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

    [HttpGet("ObtenerPorCategoria")]
    public ActionResult<List<Tesoro>> ObtenerPorCategoria(string nombre)
    {
        return Ok(_tesoroServicio.ObtenerPorCategoria(nombre));
    }
}