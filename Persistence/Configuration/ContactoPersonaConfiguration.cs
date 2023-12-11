using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ContactoPersonaConfiguration : IEntityTypeConfiguration<Contactopersona>
    {
        public void Configure(EntityTypeBuilder<Contactopersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contactopersona");

            builder.HasIndex(e => e.IdPersonaFk, "IdPersonaFk");

            builder.HasIndex(e => e.IdTipoContactoFk, "IdTipoContactoFk");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.Descripcion).HasMaxLength(50);

            builder.HasOne(d => d.IdPersonaFkNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdPersonaFk)
                .HasConstraintName("contactopersona_ibfk_1");

            builder.HasOne(d => d.IdTipoContactoFkNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdTipoContactoFk)
                .HasConstraintName("contactopersona_ibfk_2");
        }
    }
}