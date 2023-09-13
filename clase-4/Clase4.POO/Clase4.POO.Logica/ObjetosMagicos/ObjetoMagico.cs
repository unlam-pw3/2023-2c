using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase4.POO.Logica.Interfaces;

namespace Clase4.POO.Logica.ObjetosMagicos;

public class ObjetoMagico : IItem
{
    public string Nombre { get; }
    public string Efecto { get; }

    public ObjetoMagico(string nombre, string efecto)
    {
        Nombre = nombre;
        Efecto = efecto;
    }

    public void Usar(Personaje personaje)
    {
        Console.WriteLine($"{personaje.Nombre} usa {Nombre} y obtiene el efecto: {Efecto}");
    }
}