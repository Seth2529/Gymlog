using Gymlog.Dominio.ValueObjects;

namespace Gymlog.WebApp.Helper.Sessão
{
    public interface ISessao
    {
        void CriarSessaoUsuario(Pessoa pessoa);
        void RemoverSessaoUsuario();
        Pessoa BuscarSessaoUsuario();
    }
}
