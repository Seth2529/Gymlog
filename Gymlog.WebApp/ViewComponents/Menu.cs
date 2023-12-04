using Gymlog.Dominio.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Gymlog.WebApp.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            Pessoa pessoa = JsonConvert.DeserializeObject<Pessoa>(sessaoUsuario);

            return View(pessoa);
        }
    }
}
