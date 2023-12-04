using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.IRepository;
using Gymlog.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dados.Repository
{
    public class ExercicioRepository : IExercicioRepository
    {
        Contexto Contexto { get; set; }
        public ExercicioRepository(Contexto contexto) { Contexto = contexto; }

        public int EncontrarProximoIDDisponivel()
        {
            var idsExistentes = Contexto.Exercicio.Select(p => p.ExercicioID).ToList();
            int proximoID = 1;

            while (idsExistentes.Contains(proximoID))
            {
                proximoID++;
            }

            return proximoID;
        }
        public void CadastrarExercicio(Exercicio exercicio)
        {
            Contexto.Exercicio.Add(exercicio);
            Contexto.SaveChanges();
        }

        public void EditarExercicio(Exercicio exercicio)
        {
            Contexto.Exercicio.Update(exercicio);
            Contexto.SaveChanges();
        }

        public void ApagarExercicio(int exercicioID)
        {
            var Exercicio = Contexto.Exercicio.FirstOrDefault(p => p.ExercicioID.Equals(exercicioID));
            if (Exercicio != null)
            {
                Contexto.Exercicio.Remove(Exercicio);
                Contexto.SaveChanges();
            }
        }

        public Exercicio GetOneById(int exercicioID)
        {
            return Contexto.Exercicio.First(e => e.ExercicioID == exercicioID);
        }

        public IEnumerable<Exercicio> GetAll()
        {
            return Contexto.Exercicio.Where(p => true);
        }
    }
}