using System.ComponentModel.DataAnnotations;

namespace Clase6.EF.Web.Models;

public class TesoroRequestModel
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    [StringLength(maximumLength: 2000, MinimumLength = 10, ErrorMessage = "La ImagenRuta debe tener entre 10 y 2000 caracteres.")]
    public string? ImagenRuta { get; set; }

    public int? IdUbicacion { get; set; }
}