﻿namespace Clase1.Consola;

public interface IInputLector
{
    string LeerEntrada();
    void Clear();
}

public class ConsolaInputLector : IInputLector
{
    public string LeerEntrada()
    {
        return Console.ReadLine();
    }
    public void Clear()
    {
        Console.Clear();
    }
}
