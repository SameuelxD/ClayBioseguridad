using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Direccionpersona:BaseEntity
{

    public string Direccion { get; set; }

    public int? IdPersonaFk { get; set; }

    public int? IdTipoDireccionFk { get; set; }

    public virtual Persona IdPersonaFkNavigation { get; set; }

    public virtual Tipodireccion IdTipoDireccionFkNavigation { get; set; }
}
