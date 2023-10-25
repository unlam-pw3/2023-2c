using System;
using System.Collections.Generic;

namespace Clase6.EF.Data.EF;

public partial class CategoriaTesoro
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Tesoro> Tesoros { get; set; } = new List<Tesoro>();
}
