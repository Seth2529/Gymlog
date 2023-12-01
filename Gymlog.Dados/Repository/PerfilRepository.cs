using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.Entidade;
using Gymlog.Dominio.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dados.Repository
{
    public class PerfilRepository : IPerfilService
    {
        Contexto Contexto { get; set; }
        public PerfilRepository(Contexto contexto) { Contexto = contexto; }

        public IEnumerable<Perfil> GetAll()
        {
            return Contexto.Set<Perfil>().ToList();
        }
    }
}
