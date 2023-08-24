namespace Clase1.Tarea;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a Adivina el número");
        Console.WriteLine("Ingresa el número maximo a adivinar: ");
        bool estado = Int32.TryParse(Console.ReadLine(), out int numero);
        Console.WriteLine("Ya puedes empezar a adivinar...");
        bool fin = false;
        if (estado)
        {
            JuegoAdivinanza juego = new(numero, new ConsolaOutput());
            do
            {
                Console.WriteLine("Ingresa un numero: ");
                if(Int32.TryParse(Console.ReadLine(), out int numeroEscogido))
                    fin = juego.adivinar(numeroEscogido);

            } while (!fin);
        }
        else
        {
            Console.WriteLine("Numero invalido");
        }
    }
}