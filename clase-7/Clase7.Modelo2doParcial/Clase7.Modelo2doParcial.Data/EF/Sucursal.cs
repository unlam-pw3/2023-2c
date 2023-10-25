using System;
using System.Collections.Generic;

namespace Clase7.Modelo2doParcial.Data.EF;

public partial class Sucursal
{
    public int Id { get; set; }

    public string Direccion { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public int? IdCadena { get; set; }

    public virtual Cadena? IdCadenaNavigation { get; set; }
}
