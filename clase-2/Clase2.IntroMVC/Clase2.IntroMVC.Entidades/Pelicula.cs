namespace Clase2.IntroMVC.Entidades;

public class Pelicula : IEstaEnPlataforma
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public int? Anio { get; set; }
    public float? Presupuesto { get; set; }
    public float? Recaudacion { get; set; }
    public string? ImagenUrl { get; set; }
    public bool? NominadaAlOscar { get; set; }
    public bool? EstaEnNetflix { get; set; }
    public bool? EstaEnDisney { get; set; }
    public bool? EstaEnAmazon { get; set; }
    public bool? EstaEnStarPlus { get; set; }
    public bool? EstaEnHBO { get; set; }
}