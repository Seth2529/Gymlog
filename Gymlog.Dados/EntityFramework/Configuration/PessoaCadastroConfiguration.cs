using Gymlog.Dominio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dados.EntityFramework.Configuration
{
    public class PessoaCadastroConfiguration : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("PessoaCadastro");
            builder.HasKey(p => p.PessoaID);
            builder.HasAlternateKey(p => p.CPF);

            builder
                .Property(e => e.PessoaID)
                .HasColumnName("PessoaID")
                .HasColumnType("int");

            builder
                .Property(e => e.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(200)");

            builder
                .Property(e => e.Email)
                .HasColumnName("Email")
                .HasColumnType("varchar(200)");

            builder
                .Property(e => e.Cidade)
                .HasColumnName("Cidade")
                .HasColumnType("varchar(100)");

            builder
                .Property(e => e.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("date");

            builder
                .Property(e => e.CPF)
                .HasColumnName("CPF")
                .HasColumnType("char(14)");

            builder
                .Property(e => e.Senha)
                .HasColumnName("Senha")
                .HasColumnType("varchar(100)");

            builder
                .HasOne(e => e.Perfil)
                .WithMany()
                .HasForeignKey(e => e.PerfilID);
        }
    }
}
