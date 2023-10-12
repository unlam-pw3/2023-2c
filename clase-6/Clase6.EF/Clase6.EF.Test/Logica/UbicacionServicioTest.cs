using Clase6.EF.Data.EF;
using Clase6.EF.Logica;
using Clase6.EF.Test.Comun;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Clase6.EF.Test.Logica;

public class UbicacionServiceTest: TestBase
{
    public UbicacionServiceTest()
    {
    
    }

    [Fact]
    public void AgregarUbicacionTest(){
        //Arrange
        Pw32cIslaTesoroContext context = ServiceProvider.GetService<Pw32cIslaTesoroContext>();
        IUbicacionServicio ubicacionServicio = new UbicacionServicio(context);

        var ubicacion = new Ubicacion()
        {
            Id = 1,
            Nombre = "Cofre",
            
        };

        //Act
        ubicacionServicio.Agregar(ubicacion);
        
        //Assert
        var ubicacionEncontrado = context.Ubicacions.Find(ubicacion.Id);
        
        Assert.NotNull(ubicacionEncontrado);
        Assert.Equal(ubicacion.Nombre, ubicacionEncontrado.Nombre);
        Assert.Equal(ubicacion.Id, ubicacionEncontrado.Id);
        Assert.Equal(1, context.Ubicacions.Count());
    }

    [Fact]
    public void ListarUbicacionesGuardadasTest(){
        Pw32cIslaTesoroContext context = ServiceProvider.GetService<Pw32cIslaTesoroContext>();
        IUbicacionServicio ubicacionServicio = new UbicacionServicio(context);


        ubicacionServicio.Agregar(new Ubicacion()
        {
            Id = 1,
            Nombre = "Piramide",
            
        });

        ubicacionServicio.Agregar(new Ubicacion()
        {
            Id = 2,
            Nombre = "Cueva",
            
        });

        Assert.Equal(2, ubicacionServicio.ObtenerTodos().Count);
    }

    [Fact]
    public void QueSePuedaModificarUnaUbicacionTest(){
        Pw32cIslaTesoroContext context = ServiceProvider.GetService<Pw32cIslaTesoroContext>();
        IUbicacionServicio ubicacionServicio = new UbicacionServicio(context);

        ubicacionServicio.Agregar(new Ubicacion()
        {
            Id = 1,
            Nombre = "Piramide",
            
        });

        var ubicacion = ubicacionServicio.ObtenerPorId(1);
        ubicacion.Nombre = "Cueva";
        ubicacionServicio.Actualizar(ubicacion);

        Assert.Equal("Cueva", ubicacionServicio.ObtenerPorId(1).Nombre);
    }

    [Fact]
    public void EliminarUnaUbicacionTest(){
        Pw32cIslaTesoroContext context = ServiceProvider.GetService<Pw32cIslaTesoroContext>();
        IUbicacionServicio ubicacionServicio = new UbicacionServicio(context);

        ubicacionServicio.Agregar(new Ubicacion()
        {
            Id = 1,
            Nombre = "Piramide",
            
        });

        ubicacionServicio.Agregar(new Ubicacion()
        {
            Id = 2,
            Nombre = "Cueva",
            
        });

        ubicacionServicio.Eliminar(1);

        Assert.Single(ubicacionServicio.ObtenerTodos());
    }
}