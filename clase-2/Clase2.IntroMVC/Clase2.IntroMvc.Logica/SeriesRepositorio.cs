using Clase2.IntroMVC.Entidades;

namespace Clase2.IntroMvc.Logica;

public interface ISeriesRepositorio
{
    List<Serie> ObtenerTodas();
    void Agregar(Serie serie, int cantTemporadas);
    Serie? ObtenerPorId(int id);
    void Actualizar(Serie serie);
    void Eliminar(int id);
}

public class SeriesRepositorio : ISeriesRepositorio
{
    private static List<Serie> _series = new List<Serie>();
    public List<Serie> ObtenerTodas()
    {
        return _series;
    }

    public void Agregar(Serie serie, int cantidadTemporadas)
    {
        serie.Id = _series.Count + 1;
        serie.Temporadas = new List<Temporada>();
        serie.Temporadas
            .AddRange(Enumerable.Range(1, cantidadTemporadas)
            .Select(nro => new Temporada { Nro = nro }));

        _series.Add(serie);
    }

    public Serie? ObtenerPorId(int id)
    {
        return _series.FirstOrDefault(serie => serie.Id == id);
    }

    public void Actualizar(Serie serie)
    {
        var serieExistente = ObtenerPorId(serie.Id);

        if (serieExistente == null)
        {
            throw new ArgumentException($"No se encontro la serie con id {serie.Id}");
        }
        
        serieExistente.Titulo = serie.Titulo;
        serieExistente.Genero = serie.Genero;
        serieExistente.Descripcion = serie.Descripcion;
        serieExistente.ImagenUrl = serie.ImagenUrl;
        serieExistente.EstaEnNetflix = serie.EstaEnNetflix;
        serieExistente.EstaEnDisney = serie.EstaEnDisney;
        serieExistente.EstaEnAmazon = serie.EstaEnAmazon;
        serieExistente.EstaEnStarPlus = serie.EstaEnStarPlus;
        serieExistente.EstaEnHBO = serie.EstaEnHBO;
    }

    public void Eliminar(int id)
    {
        var serieExistente = ObtenerPorId(id);
        if (serieExistente == null)
            return;
        
        _series.Remove(serieExistente);
    }
}