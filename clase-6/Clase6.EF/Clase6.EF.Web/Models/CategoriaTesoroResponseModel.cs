using System.ComponentModel.DataAnnotations;

namespace Clase6.EF.Web.Models;

public class CategoriaTesoroResponseModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; } = null!;
}