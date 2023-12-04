using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.IService;
using Gymlog.Dominio.ValueObjects;
using Gymlog.WebApp.Filters;
using Gymlog.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Gymlog.WebApp.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly IPessoaCadastroService _pessoaCadastroService;

        private readonly Contexto db = new Contexto();
        public AutenticacaoController(IPessoaCadastroService pessoaCadastroService)
        {
            _pessoaCadastroService = pessoaCadastroService;
        }

        [PaginaSomenteFuncionario]
        public IActionResult Index()
        {
            var resultado = _pessoaCadastroService.GetAll();

            return View(resultado);
        }
        public IActionResult Cadastro()
        {
            ViewBag.Perfil = db.Perfil.ToList();
            return View(new PessoaViewModel());
        }

        [HttpGet]
        [PaginaSomenteFuncionario]
        public IActionResult Editar(int pessoaID)
        {
            if (pessoaID == null || pessoaID == 0)
            {
                throw new Exception("Não há dados dessa pessoa");
            }

            Pessoa editarpessoa = _pessoaCadastroService.GetOneById(pessoaID);

            if (editarpessoa == null)
            {
                return NotFound();
            }

            PessoaViewModel editarpessoaModel = new PessoaViewModel
            {
                PessoaID = editarpessoa.PessoaID,
                Nome = editarpessoa.Nome,
                Email = editarpessoa.Email,
                Cidade = editarpessoa.Cidade,
                DataNascimento = editarpessoa.DataNascimento,
                CPF = editarpessoa.CPF,
                Senha = editarpessoa.Senha,
                PerfilID = editarpessoa.PerfilID
            };

            return View(editarpessoaModel);
        }

        public IActionResult CadastrarPessoa(PessoaViewModel pessoa)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Pessoa cad = new()
                    {
                        Nome = pessoa.Nome,
                        Email = pessoa.Email,
                        Cidade = pessoa.Cidade,
                        DataNascimento = pessoa.DataNascimento,
                        CPF = pessoa.CPF,
                        Senha = pessoa.Senha,
                        PerfilID = pessoa.PerfilID
                    };
                    ViewBag.Perfil = db.Perfil.ToList();
                    _pessoaCadastroService.CadastrarPessoa(cad);
                    TempData["MensagemSucesso"] = "Pessoa cadastrada com sucesso";
                    return RedirectToAction("Cadastro");
                }
                ViewBag.Perfil = db.Perfil.ToList();
                return View("Cadastro", pessoa);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro ao cadastrar a pessoa, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Cadastro",pessoa);
            }
        }


        [PaginaSomenteFuncionario]
        public IActionResult Apagar(int pessoaID)
        {
            Pessoa apagarpessoa = _pessoaCadastroService.GetOneById(pessoaID);
            return View(apagarpessoa);
        }
        public IActionResult ApagarPessoa(int pessoaID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _pessoaCadastroService.ApagarPessoa(pessoaID);
                    TempData["MensagemSucesso"] = "Pessoa apagada com sucesso";
                    return RedirectToAction("Index");
                }

                return View(Cadastro);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em apagar a pessoa, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Index");
            }
 

        }
        [HttpPost]
        public IActionResult EditarPessoa(PessoaViewModel pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pessoa cad = new()
                    {
                        PessoaID = pessoa.PessoaID,
                        Nome = pessoa.Nome,
                        Email = pessoa.Email,
                        Cidade = pessoa.Cidade,
                        DataNascimento = pessoa.DataNascimento,
                        CPF = pessoa.CPF,
                        Senha = pessoa.Senha,
                        PerfilID = pessoa.PerfilID
                    };
                    _pessoaCadastroService.EditarPessoa(cad);
                    TempData["MensagemSucesso"] = "Cadastro editado com sucesso";
                    return RedirectToAction("Index");

                }
                return View("Editar", pessoa);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em editar o cadastro, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Editar");
            }
        }
    }
}
