using System.Numerics;

namespace Clase1.Tarea;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a Adivina el número");
        bool estado;
        do
        {
            Console.Write("Ingresa el número maximo a adivinar: ");
            estado = Int32.TryParse(Console.ReadLine(), out int numeroMaximo);
            Console.WriteLine(estado);
            Console.WriteLine("Ya puedes empezar a adivinar...");
            if (estado)
            {
                JuegoAdivinanza juego = new(numeroMaximo, new("Jugador 1", new ConsolaOutput()));
                bool fin = false;
                do
                {
                    Console.Write("Ingresa un numero: ");
                    if (Int32.TryParse(Console.ReadLine(), out int numeroEscogido))
                        fin = juego.Adivinar(numeroEscogido);

                } while (!fin);
            }
        } while (!estado);
    }
}