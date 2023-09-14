using Clase4.POO.Logica.Interfaces;

namespace Clase4.POO.Logica;

// Clase para representar un arma que implementa IAtacante
public class Arma : IAtacante
{
    public int Id { get; set; }
    public string Nombre { get; }
    public int PoderAtaque { get; }

    public Arma(int id, string nombre, int poderAtaque)
    {
        Id = id;
        Nombre = nombre;
        PoderAtaque = poderAtaque;
    }

    public void Atacar(Personaje objetivo)
    {
        Console.WriteLine($"{Nombre} ataca a {objetivo.Nombre} y hace {PoderAtaque} puntos de daño.");
        // aplicar daño al objetivo
        objetivo.HP -= PoderAtaque;
        objetivo.XP += 5;
    }
}