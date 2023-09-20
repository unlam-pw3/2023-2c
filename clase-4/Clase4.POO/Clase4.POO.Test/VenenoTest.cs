using Clase4.POO.Logica;
using Clase4.POO.Logica.Interfaces;
using Clase4.POO.Logica.ObjetosMagicos;
namespace Clase4.POO.Test;

public class VenenoTest
{
    [Fact]
    public void Verificar_Que_Al_Aplicar_El_Veneno_se_resta_HP()
    {
        // Arrange
        var veneno = new Veneno("Veneno", "Resta 10 HP");
        var personaje = new Personaje("Personaje", 100,0);
        var hpEsperado = 90;

        // Act
        veneno.Usar(personaje);

        // Assert
        Assert.Equal(hpEsperado, personaje.HP);
    }
}