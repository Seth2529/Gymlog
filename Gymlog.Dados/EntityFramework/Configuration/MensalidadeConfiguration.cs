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
    public class MensalidadeConfiguration : IEntityTypeConfiguration<Mensalidade>
    {
        public void Configure(EntityTypeBuilder<Mensalidade> builder)
        {
            builder.ToTable("Mensalidade");
            builder.HasKey(e => e.MensalidadeID);

            builder
                .Property(e => e.MensalidadeID)
                .HasColumnName("MensalidadeID")
                .HasColumnType("int");

            builder
                .HasOne(e => e.MetodoPagamentoTipo)
                .WithMany()
                .HasForeignKey(e => e.MetodoPagamentoID);

            builder
                .Property(e => e.Ativo)
                .HasColumnName("Ativo")
                .HasColumnType("bit");

        }
    }
}