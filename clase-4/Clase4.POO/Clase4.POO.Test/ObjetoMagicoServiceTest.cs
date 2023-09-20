using Clase4.POO.Logica.Servicios;
using Clase4.POO.Logica.Interfaces;
using Clase4.POO.Logica.ObjetosMagicos;
namespace Clase4.POO.Test;

public class ObjetoMagicoServiceTest
{
    private readonly IObjetoMagicoService _objetoMagicoService;

    public ObjetoMagicoServiceTest()
    {
        this._objetoMagicoService = new ObjetoMagicoService();
    }

    [Fact]
    public void Verificar_Que_Al_Agregar_Un_Objeto_Magico_Se_Agrega()
    {
        // Arrange
        var objetoMagico = new ObjetoMagico("Objeto Mágico", "Descripción");
        this._objetoMagicoService.Limpiar();
        
        // Act
        this._objetoMagicoService.Agregar(objetoMagico);

        // Assert
        Assert.Contains(objetoMagico, this._objetoMagicoService.Listar());
    }

    [Fact]
    public void Verificar_Que_Al_Agregar_Un_Objeto_Existente_Lanze_Excepcion()
    {
        // Arrange
        var objetoMagico = new ObjetoMagico("Objeto Mágico", "Descripción");
        this._objetoMagicoService.Limpiar();
        this._objetoMagicoService.Agregar(objetoMagico);

        // Act
        var excepcion = Assert.Throws<Exception>(() => this._objetoMagicoService.Agregar(objetoMagico));

        // Assert
        Assert.Equal("Ya existe un objeto mágico con ese nombre", excepcion.Message);

    }

    [Fact]
    public void Verificar_Que_Se_Puede_Obtener_La_Lista_Completa_De_Los_Objetos()
    {
        // Arrange
        var objetoMagico1 = new ObjetoMagico("Objeto Mágico 1", "Descripción");
        var objetoMagico2 = new ObjetoMagico("Objeto Mágico 2", "Descripción");
        this._objetoMagicoService.Limpiar();
        this._objetoMagicoService.Agregar(objetoMagico1);
        this._objetoMagicoService.Agregar(objetoMagico2);

        // Act
        var objetosMagicos = this._objetoMagicoService.Listar();

        // Assert
        Assert.Contains(objetoMagico1, objetosMagicos);
        Assert.Contains(objetoMagico2, objetosMagicos);
        Assert.Equal(2, objetosMagicos.Count);
    }

    [Fact]
    public void Verificar_Que_Se_Pueda_Actualizar_Un_Objeto_Magico()
    {
        // Arrange
        var objetoMagico = new ObjetoMagico("Objeto Mágico", "Descripción");
        this._objetoMagicoService.Limpiar();
        this._objetoMagicoService.Agregar(objetoMagico);
        var objetoMagicoActualizado = new ObjetoMagico(objetoMagico.Id,"Objeto Mágico Actualizado", "Descripción");
        
        // Act
        this._objetoMagicoService.Actualizar(objetoMagicoActualizado);

        // Assert
        Assert.Contains(objetoMagicoActualizado, this._objetoMagicoService.Listar());
    }

    [Fact]
    public void Verificar_Que_No_Se_Pueda_Actualizar_Un_Objeto_Magico_Inexistente()
    {
        // Arrange
        var objetoMagico = new ObjetoMagico("Objeto Mágico", "Descripción");
        this._objetoMagicoService.Limpiar();

        // Act
        var excepcion = Assert.Throws<Exception>(() => this._objetoMagicoService.Actualizar(objetoMagico));

        // Assert
        Assert.Equal("No se encontró el objeto mágico", excepcion.Message);
    }

    [Fact]
    public void Verificar_Que_Se_Puede_Obtener_Un_Objeto_Magico_Por_Id()
    {
        // Arrange
        var objetoMagico = new ObjetoMagico("Objeto Mágico", "Descripción");
        this._objetoMagicoService.Limpiar();
        this._objetoMagicoService.Agregar(objetoMagico);

        // Act
        var objetoMagicoObtenido = this._objetoMagicoService.ObtenerPorId(objetoMagico.Id);

        // Assert
        Assert.Equal(objetoMagico, objetoMagicoObtenido);
    }

    [Fact]
    public void Verificar_Que_No_Se_Pudo_Obtener_Un_Objeto_Magico()
    {
        // Arrange
        var objetoMagico = new ObjetoMagico("Objeto Mágico", "Descripción");
        this._objetoMagicoService.Limpiar();
        // Act
        var excepcion = Assert.Throws<Exception>(() => this._objetoMagicoService.ObtenerPorId(objetoMagico.Id));

        // Assert
        Assert.Equal("No se encontró el objeto mágico", excepcion.Message);
    }
}