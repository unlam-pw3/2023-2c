using Clase6.EF.Data.EF;
using Clase6.EF.Logica;
using Clase6.EF.Logica.Excepciones;
using Clase6.EF.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clase6.EF.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriaTesoroController : ControllerBase
{
    private readonly ICategoriaTesoroServicio _categoriaTesoroServicio;

    public CategoriaTesoroController(ICategoriaTesoroServicio categoriaTesoroServicio)
    {
        this._categoriaTesoroServicio = categoriaTesoroServicio;
    }

    [HttpGet]
    public List<CategoriaTesoro> Get()
    {
        return _categoriaTesoroServicio.ObtenerTodos();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var categoriaTesoro = _categoriaTesoroServicio.ObtenerPorId(id);
        if (categoriaTesoro == null)
        {
            return NotFound();
        }

        var response = new CategoriaTesoroResponseModel
        {
            Id = categoriaTesoro.Id,
            Nombre = categoriaTesoro.Nombre
        };

        return Ok(response);
    }

    [HttpPost]
    public IActionResult Post([FromBody] CategoriaTesoroRequestModel categoriaTesoroRequest)
    {
        var categoriaTesoro = new CategoriaTesoro();
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            categoriaTesoro.Nombre = categoriaTesoroRequest.Nombre;

            _categoriaTesoroServicio.Agregar(categoriaTesoro);
        }
        catch (CategoriaTesoroException ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] CategoriaTesoroRequestModel categoriaTesoroRequest)
    {
        var categoriaTesoro = new CategoriaTesoro();
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            categoriaTesoro.Id = id;
            categoriaTesoro.Nombre = categoriaTesoroRequest.Nombre;

            _categoriaTesoroServicio.Actualizar(categoriaTesoro);
        }
        catch (CategoriaTesoroException ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _categoriaTesoroServicio.Eliminar(id);
        }
        catch (CategoriaTesoroException ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }
}
