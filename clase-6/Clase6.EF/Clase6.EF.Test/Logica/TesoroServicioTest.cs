﻿using Clase6.EF.Data.EF;
using Clase6.EF.Logica;
using Clase6.EF.Test.Comun;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Clase6.EF.Test.Logica;

public class TesoroServicioTest : TestBase
{
    public TesoroServicioTest()
    {
    
    }

    [Fact]
    public void AgregarTest()
    {
        //Arrange
        Pw32cIslaTesoroContext context = ServiceProvider.GetService<Pw32cIslaTesoroContext>();
        ITesoroServicio tesoroServicio = new TesoroServicio(context);

        var tesoro = new Tesoro()
        {
            Nombre = "Cofre",
            ImagenRuta = "/imagenes/cofre.png",
        };

        //Act
        tesoroServicio.Agregar(tesoro);
        
        //Assert
        var tesoroEncontrado = context.Tesoros.Find(tesoro.Id);
        
        Assert.NotNull(tesoroEncontrado);
        Assert.Equal(tesoro.Nombre, tesoroEncontrado.Nombre);
        Assert.Equal(tesoro.ImagenRuta, tesoroEncontrado.ImagenRuta);
        Assert.Equal(1, context.Tesoros.Count());
    }

    [Fact]
    public void ListarTesorosConCategoria()
    {
        //Arrange
        Pw32cIslaTesoroContext context = ServiceProvider.GetService<Pw32cIslaTesoroContext>();
        TesoroServicio tesoroServicio = new TesoroServicio(context);

        var tesoro = new Tesoro()
        {
            Nombre = "Cofre",
            ImagenRuta = "/imagenes/cofre.png",
        };

        var categoria = new CategoriaTesoro()
        {
            Nombre = "Mitico"
        };

        tesoro.CategoriaTesoro = categoria;

        //Act
        tesoroServicio.Agregar(tesoro);
        
        //Assert
        List<Tesoro> listaTesoros = tesoroServicio.ObtenerPorCategoria(categoria.Nombre);
        
        Assert.NotNull(listaTesoros);
        Assert.NotEmpty(listaTesoros);
        Assert.Single(listaTesoros);
    }
}