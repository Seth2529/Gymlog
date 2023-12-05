using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.IService;
using Gymlog.Dominio.ValueObjects;
using Gymlog.WebApp.Filters;
using Gymlog.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gymlog.WebApp.Controllers
{
    public class FichaController : Controller
    {
        private readonly IFichaService _fichaService;

        private readonly Contexto db = new Contexto();
        public FichaController(IFichaService FichaService)
        {
            _fichaService = FichaService;
        }

        [PaginaSomenteFuncionario]
        public IActionResult Index()
        {
            var resultado = _fichaService.GetAll();

            return View(resultado);
        }
        public IActionResult CadastroF()
        {
            ViewBag.Pessoa = db.Pessoa.ToList();
            return View(new FichaViewModel());
        }

        [HttpGet]
        [PaginaSomenteFuncionario]
        public IActionResult EditarF(int FichaID)
        {
            ViewBag.Pessoa = db.Pessoa.ToList();
            if (FichaID == null || FichaID == 0)
            {
                throw new Exception("Não há dados dessa Ficha");
            }

            Ficha editarFicha = _fichaService.GetOneById(FichaID);

            if (editarFicha == null)
            {
                return NotFound();
            }

            FichaViewModel editarFichaModel = new FichaViewModel
            {
                FichaID = editarFicha.FichaID,
                NomeFicha = editarFicha.NomeFicha,
                Observacoes = editarFicha.Observacoes,
                QuantidadeSemanas = editarFicha.QuantidadeSemanas,
                PessoaID = editarFicha.PessoaID
            };

            return View(editarFichaModel);
        }
        [PaginaSomenteFuncionario]
        public IActionResult CadastrarFicha(FichaViewModel Ficha)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Ficha fich = new()
                    {
                        FichaID = Ficha.FichaID,
                        NomeFicha = Ficha.NomeFicha,
                        Observacoes = Ficha.Observacoes,
                        QuantidadeSemanas = Ficha.QuantidadeSemanas,
                        PessoaID = Ficha.PessoaID
                    };
                    ViewBag.Pessoa = db.Pessoa.ToList();
                    _fichaService.CadastrarFicha(fich);
                    TempData["MensagemSucesso"] = "Ficha cadastrada com sucesso";
                    return RedirectToAction("CadastroF");
                }
                ViewBag.Pessoa = db.Pessoa.ToList();
                return View("CadastroF", Ficha);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro ao cadastrar a ficha, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("CadastroF", Ficha);
            }
        }


        [PaginaSomenteFuncionario]
        public IActionResult ApagarF(int FichaID)
        {
            Ficha apagarFicha = _fichaService.GetOneById(FichaID);
            return View(apagarFicha);
        }
        public IActionResult ApagarFicha(int FichaID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _fichaService.ApagarFicha(FichaID);
                    TempData["MensagemSucesso"] = "ficha apagada com sucesso";
                    return RedirectToAction("Index");
                }

                return View(CadastroF);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em apagar a ficha, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Index");
            }


        }
        [PaginaSomenteFuncionario]
        [HttpPost]
        public IActionResult EditarFicha(FichaViewModel Ficha)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Ficha editfich = new()
                    {
                        FichaID = Ficha.FichaID,
                        NomeFicha = Ficha.NomeFicha,
                        Observacoes = Ficha.Observacoes,
                        QuantidadeSemanas = Ficha.QuantidadeSemanas,
                        PessoaID = Ficha.PessoaID
                    };
                    ViewBag.Pessoa = db.Pessoa.ToList();
                    _fichaService.EditarFicha(editfich);
                    TempData["MensagemSucesso"] = "Ficha editada com sucesso";
                    return RedirectToAction("Index");
                }
                ViewBag.Pessoa = db.Pessoa.ToList();
                return View("EditarF", Ficha);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em editar a ficha, tente novamente, erro: {erro.Message}";
                return RedirectToAction("EditarF");
            }
        }
    }
}