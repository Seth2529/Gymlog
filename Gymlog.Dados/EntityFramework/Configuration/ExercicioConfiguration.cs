using Gymlog.Dominio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dados.EntityFramework.Configuration
{
    public class ExercicioConfiguration : IEntityTypeConfiguration<Exercicio>
    {
        public void Configure(EntityTypeBuilder<Exercicio> builder)
        {
            builder.ToTable("Exercicio");
            builder.HasKey(e => e.ExercicioID);

            builder
                .Property(e => e.ExercicioID)
                .HasColumnName("ExercicioID")
                .HasColumnType("int");

            builder
                .Property(e => e.NomeExercicio)
                .HasColumnName("NomeExercicio")
                .HasColumnType("varchar(100)");
            builder
                .Property(e => e.TipoRepeticao)
                .HasColumnName("TipoRepeticao")
                .HasColumnType("varchar(50)");

            builder
                .HasOne(e => e.TipoRepeticao)
                .WithMany()
                .HasForeignKey(e => e.TipoRepeticaoID);

            builder
                .Property(e => e.SerieExercicio)
                .HasColumnName("SerieExercicio")
                .HasColumnType("int");

        }
    }
}
