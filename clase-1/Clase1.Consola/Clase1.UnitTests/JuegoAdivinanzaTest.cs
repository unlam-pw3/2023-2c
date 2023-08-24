using Clase1.Tarea;
using Moq;

namespace Clase1.UnitTests;

public class JuegoAdivinanzaTest
{
    [Fact]
    public void Verifica_que_al_ingresar_un_numero_adivina_numero_correcto()
    {
        // Arrange
        int numeroEscogido = 1;
        int numeroMaximo = 1;
        var mock = new Mock<IOutput>();
        mock.Setup(x => x.WriteLine(It.IsAny<string>()));
        var juego = new JuegoAdivinanza(numeroMaximo, mock.Object);

        // Act
        bool fin = juego.adivinar(numeroEscogido);

        // Assert
        Assert.True(fin);
        mock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public void Verifica_que_al_ingresar_un_numero_e_intente_adivinar_sea_incorrecto()
    {
        // Arrange
        int numeroEscogido = 2;
        int numeroMaximo = 1;
        var mock = new Mock<IOutput>();
        mock.Setup(x => x.WriteLine(It.IsAny<string>()));
        var juego = new JuegoAdivinanza(numeroMaximo, mock.Object);

        // Act
        bool fin = juego.adivinar(numeroEscogido);

        // Assert
        Assert.False(fin);
        mock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once);
    }

}
