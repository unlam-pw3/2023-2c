using System;
using System.Collections.Generic;

namespace Clase6.EF.Data.EF;

public partial class Tesoro
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ImagenRuta { get; set; }

    public int? IdUbicacion { get; set; }

    public int? CategoriaTesoroId { get; set; }

    public virtual CategoriaTesoro? CategoriaTesoro { get; set; }

    public virtual Ubicacion? IdUbicacionNavigation { get; set; }

}
