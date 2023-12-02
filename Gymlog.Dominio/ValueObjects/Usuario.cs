using Gymlog.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.ValueObjects
{
    public class Usuario
    {
        public int UsuarioID { get; set; }
        public int FichaID { get; set; }
        public Ficha Ficha { get; set; }

        public int PessoaID { get; set; }
        public Pessoa Pessoa { get; set; }

        public int HorarioID { get; set; }
        public Horario Horario { get; set; }

        public int PerfilID { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
