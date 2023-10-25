using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Clase6.EF.Data.EF;

[ModelMetadataType(typeof(TesoroValidaciones))]
public partial class Tesoro
{
}

public class TesoroValidaciones
{
    public string? ImagenRuta { get; set; }
}