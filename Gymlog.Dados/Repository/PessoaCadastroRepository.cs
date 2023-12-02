using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.Interface;
using Gymlog.Dominio.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dados.Repository
{
    public class PessoaCadastroRepository : IPessoaCadastroRepository
    {
        Contexto Contexto {  get; set; }
        public PessoaCadastroRepository(Contexto contexto) { Contexto = contexto; }

        public int EncontrarProximoIDDisponivel()
        {
            var idsExistentes = Contexto.Pessoa.Select(p => p.PessoaID).ToList();
            int proximoID = 1;

            while (idsExistentes.Contains(proximoID))
            {
                proximoID++;
            }

            return proximoID;
        }
        public Pessoa ObterPorCPF(string cpf)
        {
            return Contexto.Pessoa.FirstOrDefault(p => p.CPF == cpf);
        }
        public void CadastrarPessoa(Pessoa pessoa)
        {
            Contexto.Pessoa.Add(pessoa);
            Contexto.SaveChanges();
        }

        public void EditarPessoa(Pessoa pessoa)
        {
                Contexto.Pessoa.Update(pessoa);
                Contexto.SaveChanges();
        }

        public void ApagarPessoa(int pessoaID)
        {
            var pessoa = Contexto.Pessoa.FirstOrDefault(p => p.PessoaID.Equals(pessoaID));
            if (pessoa != null)
            {
                Contexto.Pessoa.Remove(pessoa);
                Contexto.SaveChanges();
            }
        }

        public Pessoa GetOneById(int pessoaID)
        {
            return Contexto.Pessoa.First(m => m.PessoaID == pessoaID);
        }

        public IEnumerable<Pessoa> GetAll()
        {
            return Contexto.Pessoa.Where(p => true);
        }
    }
}
