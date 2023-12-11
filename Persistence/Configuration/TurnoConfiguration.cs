using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("turno");

            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.Property(e => e.HoraFin).HasColumnType("datetime");
            builder.Property(e => e.HoraInicio).HasColumnType("datetime");
            builder.Property(e => e.Nombre).HasMaxLength(50);
        }
    }
}