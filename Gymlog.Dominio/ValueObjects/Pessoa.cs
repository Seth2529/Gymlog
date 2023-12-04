using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymlog.Dominio.Entidade;
using Gymlog.Dominio.Helper;

namespace Gymlog.Dominio.ValueObjects
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
        public virtual Perfil Perfil { get; set; }


        public bool SenhaValida(string senha)
        {

            return Senha == senha.GerarHash();
        }

        public void SetSenhaHash()
        {
            Senha = Senha.GerarHash();
        }

    }
}
