using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Persona:BaseEntity
{

    public int? IdPersonaFk { get; set; }

    public string Nombre { get; set; }

    public DateOnly? FechaRegistro { get; set; }

    public int? IdTipoPersonaFk { get; set; }

    public int? IdCategoriaFk { get; set; }

    public int? IdCiudadFk { get; set; }

    public virtual ICollection<Contactopersona> Contactopersonas { get; set; } = new List<Contactopersona>();

    public virtual ICollection<Contrato> ContratoIdClienteFkNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Contrato> ContratoIdEmpleadoFkNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Direccionpersona> Direccionpersonas { get; set; } = new List<Direccionpersona>();

    public virtual Categoriapersona IdCategoriaFkNavigation { get; set; }

    public virtual Ciudad IdCiudadFkNavigation { get; set; }

    public virtual Tipopersona IdTipoPersonaFkNavigation { get; set; }

    public virtual ICollection<Programacion> Programaciones { get; set; } = new List<Programacion>();
}
