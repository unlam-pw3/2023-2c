using System;
using System.Collections.Generic;

namespace Clase6.EF.Data.EF;

public partial class CategoriaTesoro
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int? TesoroId { get; set; }

    public virtual Tesoro? Tesoro { get; set; }
}
