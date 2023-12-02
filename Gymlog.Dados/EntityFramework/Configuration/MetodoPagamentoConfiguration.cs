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
    public class MetodoPagamentoConfiguration : IEntityTypeConfiguration<MetodoPagamento>
    {
        public void Configure(EntityTypeBuilder<MetodoPagamento> builder)
        {
            builder.ToTable("MetodoPagamento");
            builder.HasKey(e => e.MetodoPagamentoID);

            builder
                .Property(e => e.MetodoPagamentoID)
                .HasColumnName("MetodoPagamentoID")
                .HasColumnType("int");

            builder
                .Property(e => e.TipoMetodoPagamento)
                .HasColumnName("TipoMetodoPagamento")
                .HasColumnType("varchar(100)");

        }
    }
}
