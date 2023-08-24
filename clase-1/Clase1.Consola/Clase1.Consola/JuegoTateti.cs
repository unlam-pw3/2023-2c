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
    private readonly IInputLector _inputLector;
    private readonly IOutput _output;

    public JuegoTateti(IInputLector inputLector, IOutput output)
    {
        _tablero = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        _inputLector = inputLector;
        _output = output;
    }

    public JuegoTateti(IInputLector inputLector, IOutput output, char[] tablero)
    {
        _tablero = tablero;
        _inputLector = inputLector;
        _output = output;
    }
    public void Jugar()
    {
        int eleccion;

        do
        {
            _inputLector.Clear();
            ImprimirTablero();

            _turnoJugador = (_turnoJugador % 2 != 0) ? 1 : 2;

            _output.WriteLine( $"Jugador {_turnoJugador}, ingresa un número: ");
            bool entradaValida = Int32.TryParse(_inputLector.LeerEntrada(), out eleccion);

            if (entradaValida && eleccion >= 1 && eleccion <= 9 && _tablero[eleccion - 1] != 'X' && _tablero[eleccion - 1] != 'O')
            {
                _tablero[eleccion - 1] = (_turnoJugador == 1) ? 'X' : 'O';
            }
            else
            {
                _output.WriteLine("Movimiento inválido. Presiona una tecla para intentar nuevamente...");
                _inputLector.ReadKey();
                _turnoJugador--;
            }

        } while (!JuegoTerminado());

        _inputLector.Clear();
        ImprimirTablero();

        if (VerificarGanador())
            _output.WriteLine($"¡El Jugador {_turnoJugador} gana!");
        else
            _output.WriteLine("¡Es un empate!");

        _inputLector.LeerEntrada();
    }

    public bool JuegoTerminado()
    {
        return VerificarGanador() || VerificarEmpate();
    }

    public void ImprimirTablero()
    {
        _output.WriteLine($" {_tablero[0]} | {_tablero[1]} | {_tablero[2]} ");
        _output.WriteLine("---|---|---");
        _output.WriteLine($" {_tablero[3]} | {_tablero[4]} | {_tablero[5]} ");
        _output.WriteLine("---|---|---");
        _output.WriteLine($" {_tablero[6]} | {_tablero[7]} | {_tablero[8]} ");
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

