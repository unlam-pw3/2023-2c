using Microsoft.Extensions.DependencyInjection;

namespace Clase1.Consola;

class Program
{
    static void Main(string[] args)
    {
        //IInputLector lector = new ConsolaInputLector();
        //IJuegoTateti juego = new JuegoTateti(lector);
        //juego.Jugar();

        var serviceProvider = new ServiceCollection()
               .AddTransient<IInputLector, ConsolaInputLector>()
               .AddTransient<IJuegoTateti, JuegoTateti>()
               .BuildServiceProvider();

        var juego = serviceProvider.GetService<IJuegoTateti>();
        
        juego!.Jugar();
    }
}