using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.Entidade
{
    public class Horario
    {
        public int HorarioID { get; set; }
        public DateTime DataFeriado { get; set; }
        public string DiaDaSemana { get; set; }
        public string HorarioPadrao { get; set; }
        public string HorarioSabado { get; set; }

    }
}
