using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Tipocontacto:BaseEntity
{
    public string Descripcion { get; set; }

    public virtual ICollection<Contactopersona> Contactopersonas { get; set; } = new List<Contactopersona>();
}
