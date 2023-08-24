namespace Clase1.Consola;

public interface IOutput
{
    void WriteLine(string? value);
}

public class ConsolaOutput : IOutput
{
    public void WriteLine(string? value)
    {
        Console.WriteLine(value);
    }
}
