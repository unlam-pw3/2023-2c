namespace Clase6.EF.Logica.Excepciones;

public class TesorosException : Exception
{
    public TesorosException(string message) : base(message)
    {
    }
    public TesorosException(string message, Exception innerException) : base(message, innerException)
    {
    }
}