using Gymlog.Dominio.Entidade;
using Gymlog.Dominio.Interface;
using Gymlog.Dominio.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Servico.Servico
{
    public class PerfilService : IPerfilService
    {
        IPerfilService _perfilService;
        public PerfilService(IPerfilService repository)
        {
            _perfilService = repository;
        }
        public IEnumerable<Perfil> GetAll()
        {
            return _perfilService.GetAll();
        }
    }
}
