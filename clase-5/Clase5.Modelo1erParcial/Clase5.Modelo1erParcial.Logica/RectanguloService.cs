namespace Clase5.Modelo1erParcial.Logica;

public interface IRectanguloService
{
    List<Rectangulo> Listar();
    void Agregar(Rectangulo rectangulo);
}

public class RectanguloService : IRectanguloService
{
    private static List<Rectangulo> _rectangulos { get; set; } = new();
    
    public List<Rectangulo> Listar()
    {
        return _rectangulos;
    }
    
    public void Agregar(Rectangulo rectangulo)
    {
        rectangulo.Id = (_rectangulos.Max(r => r?.Id) ?? 0) + 1;
        _rectangulos.Add(rectangulo);
    }
}
