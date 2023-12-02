using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.IService;
using Gymlog.Dominio.ValueObjects;
using Gymlog.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Gymlog.WebApp.Controllers
{
    public class ExercicioController : Controller
    {
        private IExercicioService _exercicioService;

        private Contexto db = new Contexto();
        public ExercicioController(IExercicioService exercicioService)
        {
            _exercicioService = exercicioService;
        }
        public IActionResult Index()
        {
            var resultado = _exercicioService.GetAll();

            return View(resultado);
        }
        public IActionResult Inserir()
        {
            ViewBag.RepeticaoExercicio = db.RepeticaoExercicio.ToList();
            return View(new ExercicioViewModel());
        }

        [HttpGet]
        public IActionResult Editar(int ExercicioID)
        {
            if (ExercicioID == null || ExercicioID == 0)
            {
                throw new Exception("Não há dados desse exercicio");
            }

            Exercicio editarExercicio = _exercicioService.GetOneById(ExercicioID);

            if (editarExercicio == null)
            {
                return NotFound();
            }

            ExercicioViewModel editarExercicioModel = new ExercicioViewModel
            {
                ExercicioID = editarExercicio.ExercicioID,
                NomeExercicio = editarExercicio.NomeExercicio,
                TipoRepeticaoID = editarExercicio.TipoRepeticaoID,
                SerieExercicio = editarExercicio.SerieExercicio
            };
            ViewBag.RepeticaoExercicio = db.RepeticaoExercicio.ToList();

            return View(editarExercicioModel);
        }

        public IActionResult CadastrarExercicio(ExercicioViewModel exercicio)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Exercicio exerc = new()
                    {
                        NomeExercicio = exercicio.NomeExercicio,
                        TipoRepeticaoID = exercicio.TipoRepeticaoID,
                        SerieExercicio = exercicio.SerieExercicio
                    };
                    ViewBag.RepeticaoExercicio = db.RepeticaoExercicio.ToList();
                    _exercicioService.CadastrarExercicio(exerc);
                    TempData["MensagemSucesso"] = "Exercicio cadastrado com sucesso";
                    return RedirectToAction("Inserir");
                }
                ViewBag.RepeticaoExercicio = db.RepeticaoExercicio.ToList();
                return View("Inserir", exercicio);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro ao cadastrar o exercicio, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("Inserir", exercicio);
            }
        }



        public IActionResult Apagar(int ExercicioID)
        {
            Exercicio apagarExercicio = _exercicioService.GetOneById(ExercicioID);
            return View(apagarExercicio);
        }
        public IActionResult ApagarExercicio(int ExercicioID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _exercicioService.ApagarExercicio(ExercicioID);
                    TempData["MensagemSucesso"] = "Exercicio apagado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(Inserir);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em apagar o exercicio, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Index");
            }


        }
        [HttpPost]
        public IActionResult EditarExercicio(ExercicioViewModel exercicio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Exercicio exerc = new()
                    {
                        ExercicioID = exercicio.ExercicioID,
                        NomeExercicio = exercicio.NomeExercicio,
                        TipoRepeticaoID = exercicio.TipoRepeticaoID,
                        SerieExercicio = exercicio.SerieExercicio
                    };
                    ViewBag.RepeticaoExercicio = db.RepeticaoExercicio.ToList();
                    _exercicioService.EditarExercicio(exerc);
                    TempData["MensagemSucesso"] = "Cadastro editado com sucesso";
                    return RedirectToAction("Index");

                }
                ViewBag.RepeticaoExercicio = db.RepeticaoExercicio.ToList();
                return View("Editar", exercicio);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em editar o cadastro, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Editar");
            }
        }
    }
}