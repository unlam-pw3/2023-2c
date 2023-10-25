using Clase6.EF.Data.EF;
using Clase6.EF.Logica.Excepciones;
using Microsoft.EntityFrameworkCore;

namespace Clase6.EF.Logica;

public interface ITesoroServicio: IRepositorio<Tesoro>
{
    List<Tesoro> ObtenerTodosEnUbicacion(int idUbicacion);
    List<Tesoro> ObtenerPorCategoria(string Nombre);
}

public class TesoroServicio : ITesoroServicio
{
    private readonly Pw32cIslaTesoroContext _context;

    public TesoroServicio(Pw32cIslaTesoroContext context)
    {
        this._context = context;
    }

    public void Agregar(Tesoro tesoro)
    {
        this._context.Tesoros.Add(tesoro);
        this._context.SaveChanges();
    }
    public List<Tesoro> ObtenerTodos()
    {
        return this._context.Tesoros.ToList();
    }

    public Tesoro? ObtenerPorId(int id)
    {
        return this._context.Tesoros
            .Include(t=> t.IdUbicacionNavigation)
            .FirstOrDefault(t=> t.Id == id);
    }

    public void Actualizar(Tesoro tesoro)
    {
        if (tesoro.IdUbicacion.HasValue)
        {
            var ubicacion = _context.Ubicacions.Find(tesoro.IdUbicacion);
            if (ubicacion == null)
                throw new TesorosException($"No existe la ubicacion {tesoro.IdUbicacion}");
        }
        
        this._context.Tesoros.Update(tesoro);
        this._context.SaveChanges();
    }

    public void Eliminar(int id)
    {
        var tesoro = this.ObtenerPorId(id);
        
        if (tesoro == null)
            return;
        
        this._context.Tesoros.Remove(tesoro);
        this._context.SaveChanges();
    }

    public List<Tesoro> ObtenerTodosEnUbicacion(int idUbicacion)
    {
        //usando Linq
        //return (from t in _context.Tesoros
        //        where t.IdUbicacion == idUbicacion
        //        select t)
        //        .ToList();

        //Usando expresiones Lambda
        return this._context.Tesoros.Where(t => t.IdUbicacion == idUbicacion).ToList();
    }

    public List<Tesoro> ObtenerPorCategoria(string Nombre)
    {
        return this._context.Tesoros
            .Include(t => t.CategoriaTesoro)
            .Where(t => t.CategoriaTesoro != null && t.CategoriaTesoro.Nombre == Nombre)
            .ToList();
    }
}