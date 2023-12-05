using Gymlog.Dominio.ValueObjects;
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

            builder.Property(f => f.NomeFicha)
                .HasColumnName("NomeFicha")
                .HasColumnType("varchar(100)");

            builder.Property(f => f.QuantidadeSemanas)
                .HasColumnName("QuantidadeSemanas")
                .HasColumnType("int");

            builder.Property(f => f.Observacoes)
                .HasColumnName("Observacoes")
                .HasColumnType("varchar(200)");

            builder
                .HasOne(e => e.Pessoa)
                .WithMany()
                .HasForeignKey(e => e.PessoaID);
        }
    }
}
