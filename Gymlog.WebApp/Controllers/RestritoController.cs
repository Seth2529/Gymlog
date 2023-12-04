using Gymlog.WebApp.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Gymlog.WebApp.Controllers
{
    public class RestritoController : Controller
    {
        [PaginaUsuarioLogado]
        public IActionResult Index()
        {
            return View();
        }
    }
}
