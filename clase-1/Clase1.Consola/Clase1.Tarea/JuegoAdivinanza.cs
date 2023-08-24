namespace Clase1.Tarea;

public class JuegoAdivinanza{
    private readonly int _numeroMaximo;
    private readonly IOutput _output;
    private int _numeroAdivinar;
    private byte _intentos;

    public JuegoAdivinanza(int numeroMaximo, IOutput salida)
    {
        this._intentos = 1;
        this._numeroMaximo = numeroMaximo;
        this._numeroAdivinar = new Random().Next(1, numeroMaximo);
        this._output = salida;
    }

    public bool adivinar(int numero)
    {
        bool fin = false;
        if (numero == this._numeroAdivinar)
        {
            this._output.WriteLine($"Muy Bien, has adivinado el numero {this._numeroAdivinar} en {this._intentos} intentos");
            fin = true;
        }
        else
        {
            this._intentos++;
            int dif = Math.Abs(this._numeroAdivinar - numero);
            if (dif <= 5)
                this._output.WriteLine($"Estas {Estados.Ardiente}");
            else if (dif <= 10) {
                this._output.WriteLine($"Estas {Estados.Caliente}");
            } else if (dif <= 20) { 
                this._output.WriteLine($"Estas {Estados.Tibio}");
            } else if (dif <= 30) { 
                this._output.WriteLine($"Estas {Estados.Frio}"); 
            } else this._output.WriteLine($"Estas {Estados.Helado}");

        }
        return fin;
    }
}
