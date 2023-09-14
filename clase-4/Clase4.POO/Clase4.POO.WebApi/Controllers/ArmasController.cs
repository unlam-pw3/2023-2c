using Clase4.POO.Logica;
using Clase4.POO.Logica.Servicios;
using Clase4.POO.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Clase4.POO.WebApi.Controllers;

[ApiController]
[Route("api/armas")]
public class ArmasController : ControllerBase
{
    IPersonajeService _personajeService;
    public ArmasController(IPersonajeService personajeService)
    {
        _personajeService = personajeService;
    }
    
    // Propiedad estática para almacenar la información de las armas
    private static List<Arma> armas = new List<Arma>
    {
        new Arma(1, "Espada", 20),
        new Arma (2, "Arco", 15 )
    };

    // GET /api/armas
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(armas);
    }

    // POST /api/armas/atacar
    [HttpPost("atacar")]
    public IActionResult Atacar([FromBody] AtaqueRequest request)
    {
        var atacante = _personajeService.ObtenerPorId(request.AtacanteId);
        var objetivo = _personajeService.ObtenerPorId(request.ObjetivoId);
        var arma = armas.Find(a => a.Id == request.ArmaId);

        if (atacante == null || objetivo == null || arma == null)
        {
            return NotFound("No se encontró el personaje, objetivo o arma.");
        }

        arma.Atacar(objetivo);

        return Ok($"{atacante.Nombre} ataca a {objetivo.Nombre} con {arma.Nombre} y hace {arma.PoderAtaque} puntos de daño. El HP de {objetivo.Nombre} es ahora {objetivo.HP}");
    }
}