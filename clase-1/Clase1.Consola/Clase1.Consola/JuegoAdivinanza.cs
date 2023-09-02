namespace Clase1.Consola;

interface IJuegoAdivinanza
{
    int ElegirNumero(int numeroIngresado);
    string ObtenerRespuesta(float porcentajeCercania);
    float CalcularPorcentajeCercania(int numeroElegido, int numeroIngresado);
    bool JuegoTerminado();
    void Jugar();
}

public class JuegoAdivinanza : IJuegoAdivinanza
{
    private int intentos = 0;
    private int numeroMaximo;
    private string respuesta;
    private readonly IInputLector _inputLector;
    private readonly IOutput _output;

    public JuegoAdivinanza(IInputLector inputLector, IOutput output)
    {
        _inputLector = inputLector;
        _output = output;
    }

    public JuegoAdivinanza(IInputLector inputLector, IOutput output, int max)
    {
        _inputLector = inputLector;
        _output = output;
        numeroMaximo = max;
    }

    public int ElegirNumero(int numeroIngresado)
    {
        Random random = new Random();
        return random.Next(numeroIngresado + 1);
    }

    public string ObtenerRespuesta(float porcentajeCercania)
    {
        string respuesta;
        
        switch (porcentajeCercania)
        {
            case 0:
                respuesta = "Ganaste";
                break;
            case float n when (n < 10):
                respuesta = "Ardiente";
                break;
            case float n when (n < 20):
                respuesta = "Caliente";
                break;
            case float n when (n < 30):
                respuesta = "Tibio";
                break;
            case float n when (n < 40):
                respuesta = "Frío";
                break;
            default:
                respuesta = "Helado";
                break;
        }

       return respuesta;
    }

    public float CalcularPorcentajeCercania(int numeroElegido, int numeroIngresado)
    {
        float diferenciaAbsoluta = Math.Abs(numeroIngresado - numeroElegido);
        return (diferenciaAbsoluta / numeroMaximo) * 100;
    }

    public bool JuegoTerminado()
    {
        return respuesta == "Ganaste";
    }

    public void Jugar()
    {
        bool entradaValida;

        do
        {
            _inputLector.Clear();
            _output.WriteLine("Ingrese el número máximo: ");
            entradaValida = Int32.TryParse(_inputLector.LeerEntrada(), out numeroMaximo);
        } while (!entradaValida);

        int numeroElegido = ElegirNumero(numeroMaximo);
        _output.WriteLine("Ya elegí un número. Adivine: ");

        do
        {
            entradaValida = Int32.TryParse(_inputLector.LeerEntrada(), out int numeroIngresado);
            if (entradaValida && (numeroIngresado <= numeroMaximo))
            {
                intentos++;
                float porcentajeCercania = CalcularPorcentajeCercania(numeroElegido, numeroIngresado);
                respuesta = ObtenerRespuesta(porcentajeCercania);
                
                if (JuegoTerminado())
                {
                    _output.WriteLine($"¡Adivinaste! El número era {numeroElegido}. Lo adivinaste en {intentos} intentos.");
                } else
                {
                    _output.WriteLine($"{respuesta}");
                }
            }
        } while (!entradaValida || !JuegoTerminado());
    }
}