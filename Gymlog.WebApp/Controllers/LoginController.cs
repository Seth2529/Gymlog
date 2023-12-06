using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.IService;
using Gymlog.Dominio.ValueObjects;
using Gymlog.Servico.Servico;
using Gymlog.WebApp.Filters;
using Gymlog.WebApp.Helper.Sessão;
using Gymlog.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gymlog.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private readonly IPessoaCadastroService _pessoaCadastroService;
        private readonly ISessao _sessao;
        public LoginController(IPessoaCadastroService pessoaCadastroService, ISessao sessao)
        {
            _pessoaCadastroService = pessoaCadastroService;
            _sessao = sessao;
        }

        public IActionResult Index()
        {
            if(_sessao.BuscarSessaoUsuario() != null) return RedirectToAction("Index","Home");

            return View();
        }

        public IActionResult SairUsuario()
        {
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Login");
        }
      [HttpPost]
        public IActionResult Entrar(LoginViewModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pessoa pessoa = _pessoaCadastroService.ObterPorCPF(loginModel.CPF);
                    if (pessoa != null)
                    {
                        if (pessoa.SenhaValida(loginModel.Senha))
                        {
                            _sessao.CriarSessaoUsuario(pessoa);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida, tente novamente";
                    }
                    TempData["MensagemErro"] = $"CPF e/ou senha inválidos,Por favor, tente novamente";
                }
                return View("Index",loginModel);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Index", loginModel);
            }
        }

    }
}
