using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.Entidade;
using Gymlog.Dominio.IService;
using Gymlog.Dominio.ValueObjects;
using Gymlog.WebApp.Filters;
using Gymlog.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gymlog.WebApp.Controllers
{
    public class HorarioController : Controller
    {
        private readonly IHorarioService _horarioService;
        public HorarioController(IHorarioService horarioService)
        {
            _horarioService = horarioService;
        }
        [PaginaSomenteFuncionario]
        public IActionResult Index()
        {
            var resultado = _horarioService.GetAll();

            return View(resultado);
        }
        [PaginaUsuarioLogado]
        public IActionResult Details()
        {
            var resultado = _horarioService.GetAll();

            return View(resultado);
        }
        [PaginaSomenteFuncionario]
        public IActionResult CadastroH()
        {
            return View(new HorarioViewModel());
        }

        [PaginaSomenteFuncionario]
        [HttpGet]
        public IActionResult EditarH(int horarioID)
        {
            Horario editarHorario = _horarioService.GetOneById(horarioID);

            if (horarioID == null || horarioID == 0)
            {
                throw new Exception("Não há dados desse Horario");
            }

            if (editarHorario == null)
            {
                return NotFound();
            }

            HorarioViewModel editarHorarioModel = new HorarioViewModel
            {
                HorarioID = editarHorario.HorarioID,
                DataFeriado = editarHorario.DataFeriado,
                DiaDaSemana = editarHorario.DiaDaSemana,
                HorarioPadrao = editarHorario.HorarioPadrao
            };

            return View(editarHorarioModel);
        }
        [PaginaSomenteFuncionario]
        public IActionResult CadastrarHorario(HorarioViewModel horario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Horario horarioent = new()
                    {
                        DataFeriado = horario.DataFeriado,
                        DiaDaSemana = horario.DiaDaSemana,
                        HorarioPadrao = horario.HorarioPadrao
                    };
                    _horarioService.CadastrarHorario(horarioent);
                    TempData["MensagemSucesso"] = "Horario cadastrado com sucesso";
                    return RedirectToAction("CadastroH");
                }
                return View("CadastroH", horario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro ao cadastrar o Horario, tente novamente. Erro: {erro.Message}";
                return RedirectToAction("CadastroH", horario);
            }
        }


        [PaginaSomenteFuncionario]
        public IActionResult ApagarH(int horarioID)
        {
            Horario apagarHorario = _horarioService.GetOneById(horarioID);
            return View(apagarHorario);
        }
        public IActionResult ApagarHorario(int horarioID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _horarioService.ApagarHorario(horarioID);
                    TempData["MensagemSucesso"] = "Horario apagado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(CadastroH);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em apagar o Horario, tente novamente, erro: {erro.Message}";
                return RedirectToAction("Index");
            }


        }
        [PaginaSomenteFuncionario]
        [HttpPost]
        public IActionResult EditarHorario(HorarioViewModel horario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Horario hora = new()
                    {
                        HorarioID = horario.HorarioID,
                        DataFeriado = horario.DataFeriado,
                        DiaDaSemana = horario.DiaDaSemana,
                        HorarioPadrao = horario.HorarioPadrao
                    };
                    _horarioService.EditarHorario(hora);
                    TempData["MensagemSucesso"] = "Cadastro editado com sucesso";
                    return RedirectToAction("Index");

                }
                return View("Editar", horario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, houve um erro em editar o cadastro, tente novamente, erro: {erro.Message}";
                return RedirectToAction("EditarH");
            }
        }
    }
}