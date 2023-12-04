using Gymlog.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.ValueObjects
{
    public class Mensalidade
    {
        public int MensalidadeID { get; set; }

        public int MetodoPagamentoID { get; set; }
        public virtual MetodoPagamento MetodoPagamentoTipo { get; set; }

        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }

        public bool Ativo { get; set; }
    }
}