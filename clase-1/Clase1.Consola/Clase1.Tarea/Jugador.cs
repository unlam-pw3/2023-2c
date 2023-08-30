namespace Clase1.Tarea;

public class Jugador{

    private readonly string _nombre;
    private readonly IOutput _output;

    public Jugador(string nombre, IOutput salida)
    {
        this._nombre = nombre;
        this._output= salida;
    }

    public void MostrarIntento(Estados estado)
    {
        this._output.WriteLine($"Estas {estado}");
    }

    public void PartidaFinalizada(string mensage)
    {
        this._output.WriteLine($"Felicitaciones {this._nombre}, {mensage}");
    }

}
