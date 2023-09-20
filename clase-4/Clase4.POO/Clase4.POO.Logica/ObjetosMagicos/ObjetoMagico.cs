using Clase4.POO.Logica.Interfaces;

namespace Clase4.POO.Logica.ObjetosMagicos;

public class ObjetoMagico : IItem
{

    public Guid Id { get; }
    public string Nombre { get; }
    public string Efecto { get; }

    public ObjetoMagico(string nombre, string efecto)
    {
        this.Id = Guid.NewGuid();
        Nombre = nombre;
        Efecto = efecto;
    }

    public ObjetoMagico(Guid id, string nombre, string efecto)
    {
        Id = id;
        Nombre = nombre;
        Efecto = efecto;
    }

    public virtual void Usar(Personaje personaje)
    {
        
        Console.WriteLine($"{personaje.Nombre} usa {Nombre} y obtiene el efecto: {Efecto}");
    }
}