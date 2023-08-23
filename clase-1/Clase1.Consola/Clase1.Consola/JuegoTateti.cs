namespace Clase1.Consola;

interface IJuegoTateti
{
    void Jugar();
    void ImprimirTablero();
    bool VerificarGanador();
    bool VerificarEmpate();
    bool JuegoTerminado();
}

public class JuegoTateti : IJuegoTateti
{
    private char[] _tablero;
    private int _turnoJugador = 1;
    private readonly IInputLector inputLector;

    public JuegoTateti(IInputLector inputLector)
    {
        _tablero = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        this.inputLector = inputLector;
    }

    public JuegoTateti(IInputLector inputLector, char[] tablero)
    {
        _tablero = tablero;
        this.inputLector = inputLector;
    }
    public void Jugar()
    {
        int eleccion;

        do
        {
            inputLector.Clear();
            ImprimirTablero();

            _turnoJugador = (_turnoJugador % 2 != 0) ? 1 : 2;

            Console.WriteLine($"Jugador {_turnoJugador}, ingresa un número: ");
            bool entradaValida = Int32.TryParse(inputLector.LeerEntrada(), out eleccion);

            if (entradaValida && eleccion >= 1 && eleccion <= 9 && _tablero[eleccion - 1] != 'X' && _tablero[eleccion - 1] != 'O')
            {
                _tablero[eleccion - 1] = (_turnoJugador == 1) ? 'X' : 'O';
            }
            else
            {
                Console.WriteLine("Movimiento inválido. Presiona una tecla para intentar nuevamente...");
                Console.ReadKey();
                _turnoJugador--;
            }

        } while (!JuegoTerminado());

        inputLector.Clear();
        ImprimirTablero();

        if (VerificarGanador())
            Console.WriteLine($"¡El Jugador {_turnoJugador} gana!");
        else
            Console.WriteLine("¡Es un empate!");

        Console.ReadLine();
    }

    public bool JuegoTerminado()
    {
        return VerificarGanador() || VerificarEmpate();
    }

    public void ImprimirTablero()
    {
        Console.WriteLine($" {_tablero[0]} | {_tablero[1]} | {_tablero[2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {_tablero[3]} | {_tablero[4]} | {_tablero[5]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {_tablero[6]} | {_tablero[7]} | {_tablero[8]} ");
    }

    public bool VerificarGanador()
    {
        return (_tablero[0] == _tablero[1] && _tablero[1] == _tablero[2]) ||
               (_tablero[3] == _tablero[4] && _tablero[4] == _tablero[5]) ||
               (_tablero[6] == _tablero[7] && _tablero[7] == _tablero[8]) ||
               (_tablero[0] == _tablero[3] && _tablero[3] == _tablero[6]) ||
               (_tablero[1] == _tablero[4] && _tablero[4] == _tablero[7]) ||
               (_tablero[2] == _tablero[5] && _tablero[5] == _tablero[8]) ||
               (_tablero[0] == _tablero[4] && _tablero[4] == _tablero[8]) ||
               (_tablero[2] == _tablero[4] && _tablero[4] == _tablero[6]);
    }

    public bool VerificarEmpate()
    {
        return _tablero[0] != '1' && _tablero[1] != '2' && _tablero[2] != '3' &&
               _tablero[3] != '4' && _tablero[4] != '5' && _tablero[5] != '6' &&
               _tablero[6] != '7' && _tablero[7] != '8' && _tablero[8] != '9';
    }
}

