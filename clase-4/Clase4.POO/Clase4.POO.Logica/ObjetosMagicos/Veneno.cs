using Clase4.POO.Logica.Interfaces;

namespace Clase4.POO.Logica.ObjetosMagicos
{
    public class Veneno : ObjetoMagico, IItem
    {
        public Veneno(string nombre, string efecto) : base(nombre, efecto)
        {
        }

        public override void Usar(Personaje personaje)
        {
            Console.WriteLine($"{personaje.Nombre} usa {Nombre} y recibe el efecto: {Efecto}");
            // Lógica para aplicar el efecto al personaje
            personaje.HP -= 10;
        }
    }
}