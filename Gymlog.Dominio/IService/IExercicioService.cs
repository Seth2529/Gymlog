using Gymlog.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.IService
{
    public interface IExercicioService
    {
        public void CadastrarExercicio(Exercicio exercicio);
        public void EditarExercicio(Exercicio exercicio);
        public void ApagarExercicio(int exercicioID);
        public Exercicio GetOneById(int exercicioID);
        public IEnumerable<Exercicio> GetAll();
    }
}
