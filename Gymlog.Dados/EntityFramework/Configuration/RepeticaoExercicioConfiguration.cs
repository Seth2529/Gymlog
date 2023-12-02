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
    public class RepeticaoExercicioConfiguration : IEntityTypeConfiguration<RepeticaoExercicio>
    {
        public void Configure(EntityTypeBuilder<RepeticaoExercicio> builder)
        {
            builder.ToTable("RepeticaoExercicio");
            builder.HasKey(e => e.TipoRepeticaoID);

            builder
                .Property(e => e.TipoRepeticaoID)
                .HasColumnName("TipoRepeticaoID ")
                .HasColumnType("int");

            builder
                .Property(e => e.TipoRepeticao)
                .HasColumnName("TipoRepeticao")
                .HasColumnType("varchar(50)");

        }
    }
}
