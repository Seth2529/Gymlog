using Gymlog.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.ValueObjects
{
    public class FichaExercicio
    {
        public int FichaID {  get; set; }
        public virtual Ficha Ficha { get; set; }

        public int ExercicioID { get; set; }
        public virtual Exercicio Exercicio { get; set; }
    }
}
