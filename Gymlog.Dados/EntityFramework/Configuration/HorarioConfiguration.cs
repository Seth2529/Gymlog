using Gymlog.Dominio.Entidade;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dados.EntityFramework.Configuration
{
    public class HorarioConfiguration : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            builder.ToTable("Horario");
            builder.HasKey(e => e.HorarioID);

            builder
                .Property(e => e.HorarioID)
                .HasColumnName("HorarioID")
                .HasColumnType("int");

            builder
                .Property(e => e.DataFeriado)
                .HasColumnName("DataFeriado")
                .HasColumnType("date");

            builder
                .Property(e => e.DiaDaSemana)
                .HasColumnName("DiaDaSemana")
                .HasColumnType("varchar(20)");

            builder
                .Property(e => e.HorarioPadrao)
                .HasColumnName("HorarioPadrao")
                .HasColumnType("varchar(20)");

            builder
                .Property(e => e.HorarioSabado)
                .HasColumnName("HorarioSabado")
                .HasColumnType("varchar(20)");

        }
    }
}
