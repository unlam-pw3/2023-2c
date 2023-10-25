using Clase6.EF.Data.EF;
using Clase6.EF.Logica;
using Clase6.EF.Test.Comun;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Clase6.EF.Test.Logica;

public class CategoriaTesoroServicioTest : TestBase
{
    public CategoriaTesoroServicioTest()
    {
    
    }

    [Fact]
    public void AgregarTest()
    {
        //Arrange
        Pw32cIslaTesoroContext context = ServiceProvider.GetService<Pw32cIslaTesoroContext>();
        ICategoriaTesoroServicio categoriaTesoroServicio = new CategoriaTesoroServicio(context);
        var categoriaTesoro = new CategoriaTesoro
        {
            Id = 1,
            Nombre = "Mitico"
        };

        categoriaTesoroServicio.Agregar(categoriaTesoro);

        //Act
        var categoriaTesoroObtenido = categoriaTesoroServicio.ObtenerPorId(categoriaTesoro.Id);
        Assert.NotNull(categoriaTesoroObtenido);
        Assert.Equal(categoriaTesoro.Id, categoriaTesoroObtenido.Id);
        Assert.Equal(categoriaTesoro.Nombre, categoriaTesoroObtenido.Nombre);
    }

    [Fact]
    public void ListarCategorias()
    {
        //Arrange
        using Pw32cIslaTesoroContext? context = ServiceProvider.GetService<Pw32cIslaTesoroContext>();
        ICategoriaTesoroServicio categoriaTesoroServicio = new CategoriaTesoroServicio(context!);
        var categoriaTesoro = new CategoriaTesoro
        {
            Id = 1,
            Nombre = "Mitico"
        };

        categoriaTesoroServicio.Agregar(categoriaTesoro);

        //Act
        var categorias = categoriaTesoroServicio.ObtenerTodos();
        Assert.NotNull(categorias);
        Assert.NotEmpty(categorias);
        Assert.Single(categorias);
    }

}