using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gymlog.Dominio.Entidade;
using Gymlog.Dominio.Interface;
using Gymlog.Dominio.IService;

namespace Gymlog.Servico.Servico
{
    public class PessoaCadastroService : IPessoaCadastroService
    {
        IPessoaCadastroRepository _pessoaCadastroRepository;
        public PessoaCadastroService(IPessoaCadastroRepository repository)
        {
             _pessoaCadastroRepository = repository;
        }
        public bool CPFJaExiste(string cpf)
        {
            var pessoa = _pessoaCadastroRepository.ObterPorCPF(cpf);
            return pessoa != null;
        }
        public void CadastrarPessoa(Pessoa pessoa)
        {
            if (CPFJaExiste(pessoa.CPF))
            {
                throw new Exception("CPF já cadastrado");
            }

            var id = _pessoaCadastroRepository.EncontrarProximoIDDisponivel();
            pessoa.PessoaID = id;
            _pessoaCadastroRepository.CadastrarPessoa(pessoa);
        }
        public void EditarPessoa(Pessoa pessoa)
        {
            _pessoaCadastroRepository.EditarPessoa(pessoa);
        }
        public void ApagarPessoa(int pessoaID)
        {
            _pessoaCadastroRepository.ApagarPessoa(pessoaID);
        }
        public IEnumerable<Pessoa> GetAll()
        {
            return _pessoaCadastroRepository.GetAll();
        }

        public Pessoa GetOneById(int pessoaID)
        {
            return _pessoaCadastroRepository.GetOneById(pessoaID);
        }

    }
}
