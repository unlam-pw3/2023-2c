﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clase4.POO.Logica.Interfaces;

namespace Clase4.POO.Logica.ObjetosMagicos
{
    public class PocionCuracion : ObjetoMagico, IItem
    {
        public PocionCuracion(string nombre, string efecto) : base(nombre, efecto)
        {
        }

        public void Usar(Personaje personaje)
        {
            Console.WriteLine($"{personaje.Nombre} usa {Nombre} y recupera 10 puntos de vida.");
            // Lógica para aplicar el efecto al personaje
            personaje.HP += 10;
            personaje.XP += 5;
        }
    }
}
