using Clase4.POO.Logica;

namespace Clase4.POO.Test;

public class ArmaTest
{

    [Fact]
    public void Atacar_Ok()
    {
        // Arrange
        var arma = new Arma("Espada", 10);
        var personaje = new Personaje("Gandalf", 100, 0);
        var objetivo = new Personaje("Sauron", 100, 0);
        var vidaEsperada= 80;
        var experienciaEsperada = 10;

        // Act
        arma.Atacar(objetivo);
        arma.Atacar(objetivo);

        // Assert
        Assert.Equal(vidaEsperada, objetivo.HP);
        Assert.Equal(experienciaEsperada, objetivo.XP);
    }
}
