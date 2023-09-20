using Clase4.POO.Logica;
using Clase4.POO.Logica.ObjetosMagicos;
using Clase4.POO.Logica.Servicios;
using Clase4.POO.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;
namespace Clase4.POO.WebApi.Controllers;

[ApiController]
[Route("api/objetos-magicos")]
public class ObjetosMagicosController : ControllerBase
{
    IPersonajeService _personajeService;
    IObjetoMagicoService _objetoMagicoService;

    public ObjetosMagicosController(IPersonajeService personajeService, IObjetoMagicoService objetoMagicoService)
    {
        this._personajeService = personajeService;
        this._objetoMagicoService = objetoMagicoService;
    }


    [HttpGet]
    public IActionResult Get()
    {
        return Ok(this._objetoMagicoService.Listar());
    }

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        try
        {
            return Ok(_objetoMagicoService.ObtenerPorId(id));
        }
        catch (Exception)
        {
            return NotFound("No se encontró el objeto mágico.");
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] ObjetoMagicoRequest objetoMagico)
    {
        try
        {
            if (string.IsNullOrEmpty(objetoMagico.Nombre) || string.IsNullOrEmpty(objetoMagico.Efecto))
            {
                return BadRequest("El nombre y el efecto son requeridos");
            }
            _objetoMagicoService.Agregar(new ObjetoMagico(objetoMagico.Nombre, objetoMagico.Efecto));
            return Ok("Se agregó el objeto mágico");
        }
        catch (Exception)
        {
            return BadRequest("No se pudo agregar el objeto mágico");
        }
    }


    [HttpPost("usar")]
    public IActionResult Usar([FromBody] UsarObjetoRequest request)
    {
        try
        {
            Personaje? personajeOrigen = _personajeService.ObtenerPorId(request.PersonajeOrigenId);
            Personaje? personajeDestino = _personajeService.ObtenerPorId(request.PersonajeDestinoId);
            ObjetoMagico objetoMagico = _objetoMagicoService.ObtenerPorId(request.ObjetoMagicoId);
            if (personajeOrigen == null || personajeDestino == null)
            {
                return NotFound("No se encontró el personaje");
            }
            objetoMagico.Usar(personajeDestino);
            
            return Ok($"{personajeOrigen.Nombre} usa {objetoMagico.Nombre} y aplicó el efecto: {objetoMagico.Efecto} a {personajeDestino.Nombre}");
        }
        catch (Exception)
        {
            return NotFound("No se encontró el objeto mágico.");
        }
    }

    [HttpPut("actualizar/{id}")]
    public IActionResult Put(Guid id, [FromBody] ObjetoMagico objetoMagico)
    {
        try
        {
            _objetoMagicoService.Actualizar(objetoMagico);
            return Ok("Se actualizó el objeto mágico");
        }
        catch (Exception)
        {
            return NotFound("No se encontró el objeto mágico");
        }
    }
}