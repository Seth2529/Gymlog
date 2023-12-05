using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.Entidade;
using Gymlog.Dominio.IRepository;
using Gymlog.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dados.Repository
{
    public class HorarioRepository : IHorarioRepository
    {
        Contexto Contexto { get; set; }
        public HorarioRepository(Contexto contexto) { Contexto = contexto; }

        public int EncontrarProximoIDDisponivel()
        {
            var idsExistentes = Contexto.Horario.Select(p => p.HorarioID).ToList();
            int proximoID = 1;

            while (idsExistentes.Contains(proximoID))
            {
                proximoID++;
            }

            return proximoID;
        }
        public void CadastrarHorario(Horario horario)
        {
            Contexto.Horario.Add(horario);
            Contexto.SaveChanges();
        }

        public void EditarHorario(Horario horario)
        {
            Contexto.Horario.Update(horario);
            Contexto.SaveChanges();
        }

        public void ApagarHorario(int horarioID)
        {
            var horario = Contexto.Horario.FirstOrDefault(p => p.HorarioID.Equals(horarioID));
            if (horario != null)
            {
                Contexto.Horario.Remove(horario);
                Contexto.SaveChanges();
            }
        }

        public Horario GetOneById(int horarioID)
        {
            return Contexto.Horario.FirstOrDefault(p => p.HorarioID.Equals(horarioID));
        }

        public IEnumerable<Horario> GetAll()
        {
            return Contexto.Horario.Where(p => true);
        }
    }
}