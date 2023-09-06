using Clase2.IntroMVC.Entidades;

namespace Clase2.IntroMvc.Logica;

public interface IPeliculasRepositorio
{
    List<Pelicula> ObtenerTodas();
    void Agregar(Pelicula pelicula);
    Pelicula? ObtenerPorId(int id);
    void Actualizar(Pelicula pelicula);
    void Eliminar(int id);
}
public class PeliculasRepositorio : IPeliculasRepositorio
{
    private static List<Pelicula> _peliculas = new List<Pelicula>();

    public List<Pelicula> ObtenerTodas()
    {
        return _peliculas;
    }

    public void Agregar(Pelicula pelicula)
    {
        pelicula.Id = _peliculas.Count + 1;
        _peliculas.Add(pelicula);
    }

    public Pelicula? ObtenerPorId(int id)
    {
        return _peliculas.FirstOrDefault(pelicula => pelicula.Id == id);
    }

    public void Actualizar(Pelicula pelicula)
    {
        var peliculaExistente = ObtenerPorId(pelicula.Id);

        if (peliculaExistente == null)
        {
            throw new ArgumentException($"No se encontró la pelicula con id {pelicula.Id}");
        }
        
        peliculaExistente.Titulo = pelicula.Titulo;
        peliculaExistente.Genero = pelicula.Genero;
        peliculaExistente.Anio = pelicula.Anio;
        peliculaExistente.Presupuesto = pelicula.Presupuesto;
        peliculaExistente.Recaudacion = pelicula.Recaudacion;
        peliculaExistente.ImagenUrl = pelicula.ImagenUrl;
        peliculaExistente.NominadaAlOscar = pelicula.NominadaAlOscar;
        peliculaExistente.EstaEnNetflix = pelicula.EstaEnNetflix;
        peliculaExistente.EstaEnDisney = pelicula.EstaEnDisney;
        peliculaExistente.EstaEnAmazon = pelicula.EstaEnAmazon;
        peliculaExistente.EstaEnStarPlus = pelicula.EstaEnStarPlus;
        peliculaExistente.EstaEnHBO = pelicula.EstaEnHBO;
    }

    public void Eliminar(int id)
    {
        var peliculaExistente = ObtenerPorId(id);

        if (peliculaExistente == null)
        {
            throw new ArgumentException($"No se encontro la pelicula con id {id}");
        }

        _peliculas.Remove(peliculaExistente);
    }   
}