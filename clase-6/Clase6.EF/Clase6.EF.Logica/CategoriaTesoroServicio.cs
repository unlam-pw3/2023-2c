using Clase6.EF.Data.EF;
using Clase6.EF.Logica.Excepciones;
using Microsoft.EntityFrameworkCore;

namespace Clase6.EF.Logica;

public interface ICategoriaTesoroServicio
{
    void Agregar(CategoriaTesoro categoriaTesoro);
    List<CategoriaTesoro> ObtenerTodos();
    CategoriaTesoro? ObtenerPorId(int id);
    void Actualizar(CategoriaTesoro categoriaTesoro);
    void Eliminar(int id);
}

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
        if(_context.CategoriaTesoros.Find(id) == null)
        {
            throw new CategoriaTesoroException("No existe la categoría");
        }
        _context.CategoriaTesoros.Remove(_context.CategoriaTesoros.Find(id));
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