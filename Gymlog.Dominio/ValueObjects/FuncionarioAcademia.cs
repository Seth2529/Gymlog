using Gymlog.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.ValueObjects
{
    public class FuncionarioAcademia
    {
        public int FuncionarioAcademiaID {  get; set; }
        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public int MensalidadeID { get; set; }
        public virtual Mensalidade Mensalidade { get; set;}

        public int FichaID { get; set; }
        public virtual Ficha Ficha { get; set; }

        public int HorarioID { get; set; }
        public virtual Horario Horario { get; set; }

        public int PerfilID { get; set; }
        public virtual Perfil Perfil { get; set; }

    }
}
