using Gymlog.Dados.EntityFramework;
using Gymlog.WebApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gymlog.WebApp.Controllers
{
    [PaginaUsuarioLogado]
    public class HorarioController : Controller
    {
        private readonly Contexto db = new Contexto();
        public IActionResult Index()
        {
            var resultado = db.Horario.ToList();

            return View(resultado);
        }
    }
}
