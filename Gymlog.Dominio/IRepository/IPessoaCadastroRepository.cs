using Gymlog.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.Interface
{
    public interface IPessoaCadastroRepository
    {
        public void CadastrarPessoa(Pessoa pessoa);
        public void EditarPessoa(Pessoa pessoa);
        public void ApagarPessoa(int pessoaID);
        public Pessoa GetOneById(int pessoaID);
        public IEnumerable<Pessoa> GetAll();
        public int EncontrarProximoIDDisponivel();
        public Pessoa ObterPorCPF(string cpf);
    }
}
