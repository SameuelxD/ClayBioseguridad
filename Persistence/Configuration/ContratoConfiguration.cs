using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class ContratoConfiguration : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contrato");

            builder.HasIndex(e => e.IdClienteFk, "IdClienteFk");

            builder.HasIndex(e => e.IdEmpleadoFk, "IdEmpleadoFk");

            builder.HasIndex(e => e.IdEstadoFk, "IdEstadoFk");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.HasOne(d => d.IdClienteFkNavigation).WithMany(p => p.ContratoIdClienteFkNavigations)
                .HasForeignKey(d => d.IdClienteFk)
                .HasConstraintName("contrato_ibfk_1");

            builder.HasOne(d => d.IdEmpleadoFkNavigation).WithMany(p => p.ContratoIdEmpleadoFkNavigations)
                .HasForeignKey(d => d.IdEmpleadoFk)
                .HasConstraintName("contrato_ibfk_2");

            builder.HasOne(d => d.IdEstadoFkNavigation).WithMany(p => p.Contratos)
                .HasForeignKey(d => d.IdEstadoFk)
                .HasConstraintName("contrato_ibfk_3");
        }
    }
}