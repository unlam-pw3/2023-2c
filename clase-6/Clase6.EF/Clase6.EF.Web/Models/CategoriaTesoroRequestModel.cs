using System.ComponentModel.DataAnnotations;

namespace Clase6.EF.Web.Models;

public class CategoriaTesoroRequestModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = null!;
}