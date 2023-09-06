namespace Clase2.IntroMVC.Entidades;

public class Serie: IEstaEnPlataforma
{
    public int Id { get; set; }
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public string? Descripcion { get; set; }
    public string? ImagenUrl { get; set; }
    public List<Temporada>? Temporadas { get; set; }
    public bool? EstaEnNetflix { get; set; }
    public bool? EstaEnDisney { get; set; }
    public bool? EstaEnAmazon { get; set; }
    public bool? EstaEnStarPlus { get; set; }
    public bool? EstaEnHBO { get; set; }
}