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
        public Pessoa Pessoa { get; set; }
        public int MensalidadeID { get; set; }
        public string Mensalidade { get; set;}
        public int FichaID { get; set; }
        public int HorarioID { get; set; }

        public int PerfilID { get; set; }
        public string Perfil { get; set; }

    }
}
