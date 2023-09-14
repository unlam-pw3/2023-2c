using Clase4.POO.Logica;
using Clase4.POO.Logica.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Clase4.POO.WebApi.Controllers;

[ApiController]
[Route("api/personajes")]
public class PersonajesController : ControllerBase
{
    IPersonajeService _personajeService;
    public PersonajesController(IPersonajeService personajeService)
    {
        _personajeService = personajeService;
    }

    // GET /api/personajes
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_personajeService.Listar());
    }

    // POST /api/personajes
    [HttpPost]
    public IActionResult Post([FromBody] Personaje personaje)
    {
        // Asignar un ID único al personaje
        _personajeService.Agregar(personaje);
        return CreatedAtAction(nameof(Get), new { id = personaje.Id }, personaje);
    }

    // GET /api/personajes/{id}
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var personaje = _personajeService.ObtenerPorId(id);
        if (personaje == null)
        {
            return NotFound();
        }
        return Ok(personaje);
    }

    // PUT /api/personajes/{id}
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Personaje personaje)
    {
        var existingPersonaje = _personajeService.Actualizar(personaje);
        if (existingPersonaje == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
