using System;

namespace Clase1.Consola;

class Program
{
    static char[] tablero = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    static int turnoJugador = 1; // Comienza el Jugador 1

    static void Main(string[] args)
    {
        bool juegoTerminado = false;
        int eleccion;

        do
        {
            Console.Clear();
            ImprimirTablero();

            // Alternar entre jugadores
            turnoJugador = (turnoJugador % 2 != 0) ? 1 : 2;

            Console.WriteLine($"Jugador {turnoJugador}, ingresa un número: ");
            bool entradaValida = Int32.TryParse(Console.ReadLine(), out eleccion);

            if (entradaValida && eleccion >= 1 && eleccion <= 9 && tablero[eleccion - 1] != 'X' && tablero[eleccion - 1] != 'O')
            {
                tablero[eleccion - 1] = (turnoJugador == 1) ? 'X' : 'O';
            }
            else
            {
                Console.WriteLine("Movimiento inválido. Presiona una tecla para intentar nuevamente...");
                Console.ReadKey();
                turnoJugador--;
            }

            juegoTerminado = VerificarGanador() || VerificarEmpate();

        } while (!juegoTerminado);

        Console.Clear();
        ImprimirTablero();

        if (VerificarGanador())
            Console.WriteLine($"¡El Jugador {turnoJugador} gana!");
        else
            Console.WriteLine("¡Es un empate!");

        Console.ReadLine();
    }

    static void ImprimirTablero()
    {
        Console.WriteLine($" {tablero[0]} | {tablero[1]} | {tablero[2]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {tablero[3]} | {tablero[4]} | {tablero[5]} ");
        Console.WriteLine("---|---|---");
        Console.WriteLine($" {tablero[6]} | {tablero[7]} | {tablero[8]} ");
    }

    static bool VerificarGanador()
    {
        // Verificar filas, columnas y diagonales
        return (tablero[0] == tablero[1] && tablero[1] == tablero[2]) ||
               (tablero[3] == tablero[4] && tablero[4] == tablero[5]) ||
               (tablero[6] == tablero[7] && tablero[7] == tablero[8]) ||
               (tablero[0] == tablero[3] && tablero[3] == tablero[6]) ||
               (tablero[1] == tablero[4] && tablero[4] == tablero[7]) ||
               (tablero[2] == tablero[5] && tablero[5] == tablero[8]) ||
               (tablero[0] == tablero[4] && tablero[4] == tablero[8]) ||
               (tablero[2] == tablero[4] && tablero[4] == tablero[6]);
    }

    static bool VerificarEmpate()
    {
        return tablero[0] != '1' && tablero[1] != '2' && tablero[2] != '3' &&
               tablero[3] != '4' && tablero[4] != '5' && tablero[5] != '6' &&
               tablero[6] != '7' && tablero[7] != '8' && tablero[8] != '9';
    }
}