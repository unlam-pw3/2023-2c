using Clase1.Consola;
using Moq;

namespace Clase1.UnitTests;

public class JuegoAdivinanzaTests
{
    [Fact]
    public void ElNumeroElegidoEstaDentroDelRango()
    {
        var mockLector = new Mock<IInputLector>();
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoAdivinanza(mockLector.Object, mockOutput.Object);

        Assert.True(juego.ElegirNumero(50) <= 50);
    }

    [Fact]
    public void ElUsuarioIngresaElNumeroCorrecto()
    {
        var mockInputLector = new Mock<IInputLector>();
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoAdivinanza(mockInputLector.Object, mockOutput.Object, 100);

        var respuesta = juego.ObtenerRespuesta(juego.CalcularPorcentajeCercania(50, 50));

        Assert.Equal("Ganaste", respuesta);
    }

    [Fact]
    public void ElUsuarioIngresaUnNumeroArdiente()
    {
        var mockInputLector = new Mock<IInputLector>();
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoAdivinanza(mockInputLector.Object, mockOutput.Object, 100);

        var respuesta = juego.ObtenerRespuesta(juego.CalcularPorcentajeCercania(50, 45));

        Assert.Equal("Ardiente", respuesta);
    }

    [Fact]
    public void ElUsuarioIngresaUnNumeroCaliente()
    {
        var mockInputLector = new Mock<IInputLector>();
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoAdivinanza(mockInputLector.Object, mockOutput.Object, 100);

        var respuesta = juego.ObtenerRespuesta(juego.CalcularPorcentajeCercania(50, 40));

        Assert.Equal("Caliente", respuesta);
    }

    [Fact]
    public void ElUsuarioIngresaUnNumeroTibio()
    {
        var mockInputLector = new Mock<IInputLector>();
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoAdivinanza(mockInputLector.Object, mockOutput.Object, 100);

        var respuesta = juego.ObtenerRespuesta(juego.CalcularPorcentajeCercania(50, 30));

        Assert.Equal("Tibio", respuesta);
    }

    [Fact]
    public void ElUsuarioIngresaUnNumeroFrio()
    {
        var mockInputLector = new Mock<IInputLector>();
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoAdivinanza(mockInputLector.Object, mockOutput.Object, 100);

        var respuesta = juego.ObtenerRespuesta(juego.CalcularPorcentajeCercania(50, 20));

        Assert.Equal("Frío", respuesta);
    }

    [Fact]
    public void ElUsuarioIngresaUnNumeroHelado()
    {
        var mockInputLector = new Mock<IInputLector>();
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoAdivinanza(mockInputLector.Object, mockOutput.Object, 100);

        var respuesta = juego.ObtenerRespuesta(juego.CalcularPorcentajeCercania(50, 10));

        Assert.Equal("Helado", respuesta);
    }

}