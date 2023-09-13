namespace Clase4.POO.Logica.Interfaces;

/// <summary>
/// Interfaz para objetos que pueden ser utilizados por un personaje
/// </summary>
public interface IItem
{
    string Nombre { get; }
    void Usar(Personaje personaje);
}
