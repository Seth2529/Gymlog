using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.Entidade
{
    public class Pessoa
    {
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cidade { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public int PerfilID { get; set; }
        public virtual Pessoa Perfil { get; set; }

    }       
}
