using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data;

public partial class ClayContext : DbContext
{
    public ClayContext()
    {
    }

    public ClayContext(DbContextOptions<ClayContext> options)
        : base(options)
    {
    }


    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserRol> UserRoles { get; set; }
    public virtual DbSet<Rol> Roles { get; set; }
    public virtual DbSet<Categoriapersona> CategoriaPersonas { get; set; }

    public virtual DbSet<Ciudad> Ciudades { get; set; }

    public virtual DbSet<Contactopersona> ContactoPersonas { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Direccionpersona> DireccionPersonas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Pais> Paises { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Programacion> Programaciones { get; set; }

    public virtual DbSet<Tipocontacto> TipoContactos { get; set; }

    public virtual DbSet<Tipodireccion> TipoDirecciones { get; set; }

    public virtual DbSet<Tipopersona> TipoPersonas { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}


