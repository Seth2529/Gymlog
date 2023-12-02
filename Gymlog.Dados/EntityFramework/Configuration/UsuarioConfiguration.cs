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
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(f => f.UsuarioID);

            builder.Property(f => f.UsuarioID).
                HasColumnName("UsuarioID").
                HasColumnType("int");

            builder.HasOne(f => f.Pessoa)
                .WithMany()
                .HasForeignKey(f => f.PessoaID);

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