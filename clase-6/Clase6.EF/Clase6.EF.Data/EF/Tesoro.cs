using System;
using System.Collections.Generic;

namespace Clase6.EF.Data.EF;

public partial class Tesoro
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? ImagenRuta { get; set; }
}
