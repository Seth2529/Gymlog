using Gymlog.Dados.EntityFramework.Configuration;
using Gymlog.Dominio.Entidade;
using Gymlog.Dominio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dados.EntityFramework
{
    public class Contexto : DbContext
    {
        public DbSet<Exercicio> Exercicio { get; set; }
        //public DbSet<RepeticaoExercicio> RepeticaoExercicio { get; set; }
        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<FuncionarioAcademia> FuncionarioAcademia { get; set; }
        public DbSet<Perfil> Perfil { get; set; }

        public Contexto(): base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG
            optionsBuilder.UseSqlServer(@"Data source = 10.107.176.41, 1434; 
                                    Database = BD045201; 
                                    User ID = RA045201; 
                                    Password = 045201;
                                    TrustServerCertificate = True;");
#else
            optionsBuilder.UseSqlServer(@"Data source = 201.62.57.93,1434; 
                                    Database = BD045201; 
                                    User ID = RA045201; 
                                    Password = 045201;
                                    TrustServerCertificate = True;");
#endif

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Exercicio>()
            //    .HasOne(e => e.TipoRepeticaoID)
            //    .WithMany()
            //    .HasForeignKey(e => e.TipoRepeticaoID);
            //modelBuilder.ApplyConfiguration(new ExercicioConfiguration());
            //modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            //modelBuilder.ApplyConfiguration(new FuncionarioAcademiaConfiguration());
            modelBuilder.ApplyConfiguration(new PessoaCadastroConfiguration());
            modelBuilder.ApplyConfiguration(new PerfilConfiguration());
        }


    }
}
