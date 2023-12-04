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
        public string NomeFicha { get; set; }
        public string Observacoes { get; set;}
        public int QuantidadeSemanas { get; set; }

        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
