using Clase1.Consola;
using Moq;

namespace Clase1.UnitTests;

public class JuegoTatetiTests
{

    [Fact]
    public void VerificarGanador_GanadorEnFila_DebeDevolverVerdadero()
    {
        var mockLector = new Mock<IInputLector>();
        mockLector.SetupSequence(lector => lector.LeerEntrada())
            .Returns("1")
            .Returns("2")
            .Returns("3");
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoTateti(mockLector.Object, mockOutput.Object, new char[] { 'X', 'X', 'X', '4', '5', '6', '7', '8', '9' });

        bool resultado = juego.VerificarGanador();

        Assert.True(resultado);
    }

    [Fact]
    public void VerificarEmpate_TableroLleno_DebeDevolverVerdadero()
    {
        var mockLector = new Mock<IInputLector>();
        mockLector.SetupSequence(lector => lector.LeerEntrada())
            .Returns("1")
            .Returns("2")
            .Returns("3");
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoTateti(mockLector.Object, mockOutput.Object, new char[] { 'X', 'O', 'X', 'X', 'O', 'X', 'O', 'X', 'O' });

        bool resultado = juego.VerificarEmpate();

        Assert.True(resultado);
    }

    [Fact]
    public void Jugar_TresMovimientosValidos_JuegoTerminadoDebeSerVerdadero()
    {
        var mockLector = new Mock<IInputLector>();
        mockLector.SetupSequence(lector => lector.LeerEntrada())
            .Returns("1")
            .Returns("2")
            .Returns("3");
        
        var mockOutput = new Mock<IOutput>();

        var juego = new JuegoTateti(mockLector.Object, mockOutput.Object);
        juego.Jugar();

        Assert.True(juego.JuegoTerminado());
    }
}