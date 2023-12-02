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
    public class FichaConfiguration : IEntityTypeConfiguration<Ficha>
    {
        public void Configure(EntityTypeBuilder<Ficha> builder)
        {
            builder.ToTable("Ficha");
            builder.HasKey(f => f.FichaID);

            builder.Property(f => f.FichaID).
                HasColumnName("FichaID").
                HasColumnType("int");

            builder.Property(f => f.QuantidadeSemanas)
                .HasColumnName("QuantidadeSemanas");

            builder.Property(f => f.Observacoes)
                .HasColumnName("Observacoes")
                .HasColumnType("varchar(200)");

            builder.HasMany(f => f.Exercicio)
                .WithOne()
                .HasForeignKey(e => e.ExercicioID);
        }
    }
}
