using Clase4.POO.Logica;
using Clase4.POO.Logica.ObjetosMagicos;

namespace Clase4.POO.Test
{
    public class PocionCuracionTest
    {
        [Fact]
        public void Usar_Ok()
        {
            // Arrange
            var pocionCuracion = new PocionCuracion("Poción de curación", "Recupera 10 puntos de vida.");
            var personaje = new Personaje("Gandalf", 100, 100);
            var vidaEsperada = 110;
            var experienciaEsperada = 105;

            // Act
            pocionCuracion.Usar(personaje);

            // Assert
            Assert.Equal(vidaEsperada, personaje.HP);
            Assert.Equal(experienciaEsperada, personaje.XP);
        }
    }
}
