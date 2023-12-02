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
    public class FuncionarioAcademiaConfiguration : IEntityTypeConfiguration<FuncionarioAcademia>
    {
        public void Configure(EntityTypeBuilder<FuncionarioAcademia> builder)
        {
            builder.ToTable("FuncionarioAcademia");
            builder.HasKey(f => f.FuncionarioAcademiaID);

            builder.Property(f => f.FuncionarioAcademiaID).
                HasColumnName("FuncionarioAcademiaID").
                HasColumnType("int");

            builder.HasOne(f => f.Pessoa)
                .WithMany()
                .HasForeignKey(f => f.PessoaID);

            builder.HasOne(f => f.Mensalidade)
                .WithMany()
                .HasForeignKey(e => e.MensalidadeID);

            builder.HasOne(f => f.Ficha)
                .WithMany()
                .HasForeignKey(e => e.FichaID);

            builder.HasOne(f => f.Horario)
                .WithMany()
                .HasForeignKey(e => e.HorarioID);

            builder
                .HasOne(e => e.Perfil)
                .WithMany()
                .HasForeignKey(e => e.PerfilID);
        }
    }
}