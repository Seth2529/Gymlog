using Gymlog.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.IService
{
    public interface IPessoaCadastroService
    {
        public void CadastrarPessoa(Pessoa pessoa);
        public void EditarPessoa(Pessoa pessoa);
        public void ApagarPessoa(int pessoaID);
        public Pessoa GetOneById(int pessoaID);
        public IEnumerable<Pessoa> GetAll();
        public bool CPFJaExiste(string cpf);
    }
}
