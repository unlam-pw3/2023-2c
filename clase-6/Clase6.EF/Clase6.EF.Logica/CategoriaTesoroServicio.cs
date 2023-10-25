using Clase6.EF.Data.EF;
using Clase6.EF.Logica.Excepciones;
using Microsoft.EntityFrameworkCore;

namespace Clase6.EF.Logica;

public interface ICategoriaTesoroServicio : IRepositorio<CategoriaTesoro> {}

public class CategoriaTesoroServicio : ICategoriaTesoroServicio
{
    private readonly Pw32cIslaTesoroContext _context;

    public CategoriaTesoroServicio(Pw32cIslaTesoroContext context)
    {
        this._context = context;
    }

    public void Actualizar(CategoriaTesoro categoriaTesoro)
    {
        if(_context.CategoriaTesoros.Find(categoriaTesoro.Id) == null)
        {
            throw new CategoriaTesoroException("No existe la categoría");
        }
        _context.CategoriaTesoros.Update(categoriaTesoro);
        _context.SaveChanges();
    }

    public void Agregar(CategoriaTesoro categoriaTesoro)
    {
        if(_context.CategoriaTesoros.Any(x => x.Nombre == categoriaTesoro.Nombre))
        {
            throw new CategoriaTesoroException("Ya existe una categoría con ese nombre");
        }
        _context.CategoriaTesoros.Add(categoriaTesoro);
        _context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var categoria = _context.CategoriaTesoros.Find(id) ?? throw new CategoriaTesoroException("No existe la categoría");
        _context.CategoriaTesoros.Remove(categoria);
        _context.SaveChanges();
    }

    public CategoriaTesoro? ObtenerPorId(int id)
    {
        return _context.CategoriaTesoros.FirstOrDefault(x => x.Id == id);
    }

    public List<CategoriaTesoro> ObtenerTodos()
    {
        return _context.CategoriaTesoros.ToList();
    }
}