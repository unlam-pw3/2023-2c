namespace Clase1.Tarea;

public class JuegoAdivinanza
{
    private Jugador _player;
    private int _numeroAdivinar;
    private byte _intentos;

    public JuegoAdivinanza(int numeroMaximo, Jugador player)
    {
        this._intentos = 1;
        this._numeroAdivinar = new Random().Next(1, numeroMaximo);
        this._player = player;
    }

    public bool Adivinar(int numero)
    {
        bool fin = false;
        if (numero == this._numeroAdivinar)
        {
            this._player.PartidaFinalizada($"has adivinado el número {this._numeroAdivinar} en {this._intentos} intentos");
            fin = true;
        }
        else
        {
            this._intentos++;
            Estados resultado = Estados.Helado;
            int dif = Math.Abs(this._numeroAdivinar - numero);
            if (dif <= 5)
            {
                resultado = Estados.Ardiente;
            }
            else if (dif <= 10)
            {
                resultado = Estados.Caliente;
            }
            else if (dif <= 20)
            {
                resultado = Estados.Tibio;
            }
            else if (dif <= 30)
            {
                resultado = Estados.Frio;
            }
            this._player.MostrarIntento(resultado);
        }
        return fin;
    }
}
