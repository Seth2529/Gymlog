using Gymlog.Dominio.ValueObjects;
using Newtonsoft.Json;

namespace Gymlog.WebApp.Helper.Sessão
{
    public class Sessao : ISessao
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public Sessao(IHttpContextAccessor httpContext) 
        {
            _contextAccessor = httpContext;
        }

        public Pessoa BuscarSessaoUsuario()
        {
            string sessaoUsuario = _contextAccessor.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<Pessoa>(sessaoUsuario);
        }

        public void CriarSessaoUsuario(Pessoa pessoa)
        {
            string valor = JsonConvert.SerializeObject(pessoa);
            _contextAccessor.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoverSessaoUsuario()
        {
            _contextAccessor.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
