namespace Clase4.POO.Logica.Interfaces;

/// <summary>
/// Interfaz para objetos que pueden atacar
/// </summary>
public interface IAtacante
{
    int PoderAtaque { get; }
    void Atacar(Personaje objetivo);
}