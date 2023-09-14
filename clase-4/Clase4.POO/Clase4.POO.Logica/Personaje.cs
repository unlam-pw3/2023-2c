using Clase4.POO.Logica.Interfaces;

namespace Clase4.POO.Logica;

/// <summary>
/// Clase base para representar un personaje en el juego
/// </summary>
public class Personaje
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public int XP { get; set; }
    public int HP { get; set; }
    public List<IItem> ObjetosEquipados { get; } = new List<IItem>();

    public Personaje(string nombre, int hp, int xp)
    {
        Id = Guid.NewGuid();
        Nombre = nombre;
        HP = hp;
        XP = xp;
    }
}

