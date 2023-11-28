using Gymlog.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Gymlog.Dominio.ValueObjects
{
    public class Exercicio
    {
        public int ExercicioID { get; set; }
        public string NomeExercicio { get; set; }
        public int TipoRepeticaoID { get; set; }
        public virtual Exercicio TipoRepeticao { get; set; }
        public int SerieExercicio { get; set; }
    }
}
