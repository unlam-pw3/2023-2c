using Clase6.EF.Data.EF;

namespace Clase6.EF.Logica;

public interface ITesoroServicio
{
    void Agregar(Tesoro tesoro);
    List<Tesoro> ObtenerTodos();
    Tesoro ObtenerPorId(int id);
    void Actualizar(Tesoro tesoro);
    void Eliminar(int id);
}

public class TesoroServicio : ITesoroServicio
{
    private Pw32cIslaTesoroContext _context;

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

    public Tesoro ObtenerPorId(int id)
    {
        return this._context.Tesoros.Find(id);
    }

    public void Actualizar(Tesoro tesoro)
    {
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
}