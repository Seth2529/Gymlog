using Gymlog.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.IRepository
{
    public interface IHorarioRepository
    {
        public void CadastrarHorario(Horario horario);
        public void EditarHorario(Horario horario);
        public void ApagarHorario(int horarioID);
        public Horario GetOneById(int horarioID);
        public IEnumerable<Horario> GetAll();
        public int EncontrarProximoIDDisponivel();
    }
}
