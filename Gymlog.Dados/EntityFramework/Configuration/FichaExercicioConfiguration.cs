using Gymlog.Dominio.Entidade;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymlog.Dominio.ValueObjects;

namespace Gymlog.Dados.EntityFramework.Configuration
{
    public class FichaExercicioConfiguration : IEntityTypeConfiguration<FichaExercicio>
    {
        public void Configure(EntityTypeBuilder<FichaExercicio> builder)
        {
            builder.ToTable("FichaExercicio");
            builder.HasKey(f => f.FichaID);

            builder
                .HasOne(e => e.Ficha)
                .WithMany()
                .HasForeignKey(e => e.FichaID);

            builder
                .HasOne(e => e.Exercicio)
                .WithMany()
                .HasForeignKey(e => e.ExercicioID);
        }
    }
}
