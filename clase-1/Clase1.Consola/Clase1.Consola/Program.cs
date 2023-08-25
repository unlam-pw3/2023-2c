using Microsoft.Extensions.DependencyInjection;

namespace Clase1.Consola;

class Program
{
    static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
               .AddTransient<IInputLector, ConsolaInputLector>()
               .AddTransient<IOutput, ConsolaOutput>()
               .AddTransient<IJuegoAdivinanza, JuegoAdivinanza>()
               .BuildServiceProvider();

        var juego = serviceProvider.GetService<IJuegoAdivinanza>();

        juego!.Jugar();
    }
}