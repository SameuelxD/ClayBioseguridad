using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("persona");

            builder.HasIndex(e => e.IdCategoriaFk, "IdCategoriaFk");

            builder.HasIndex(e => e.IdCiudadFk, "IdCiudadFk");

            builder.HasIndex(e => e.IdTipoPersonaFk, "IdTipoPersonaFk");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Nombre).HasMaxLength(50);

            builder.HasOne(d => d.IdCategoriaFkNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCategoriaFk)
                .HasConstraintName("persona_ibfk_2");

            builder.HasOne(d => d.IdCiudadFkNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdCiudadFk)
                .HasConstraintName("persona_ibfk_3");

            builder.HasOne(d => d.IdTipoPersonaFkNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoPersonaFk)
                .HasConstraintName("persona_ibfk_1");
        }
    }
}