using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymlog.Dominio.ValueObjects;

namespace Gymlog.Dominio.Entidade
{
    public class Ficha
    {
        public int FichaID { get; set; }
        public int ExercicioID {  get; set; }
        public List<Exercicio> Exercicio { get; set; }
        public int QuantidadeSemanas { get; set; }
        public string Observacoes { get; set;}
    }
}
