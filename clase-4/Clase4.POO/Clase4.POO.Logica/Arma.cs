using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase4.POO.Logica.Interfaces;

namespace Clase4.POO.Logica;

// Clase para representar un arma que implementa IAtacante
public class Arma : IAtacante
{
    public string Nombre { get; }
    public int PoderAtaque { get; }

    public Arma(string nombre, int poderAtaque)
    {
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