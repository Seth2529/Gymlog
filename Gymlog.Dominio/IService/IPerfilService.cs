using Gymlog.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.IService
{
    public interface IPerfilService
    {
        public IEnumerable<Perfil> GetAll();
    }
}
