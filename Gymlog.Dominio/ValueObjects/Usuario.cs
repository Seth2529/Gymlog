using Gymlog.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.ValueObjects
{
    public class Usuario
    {
        public int UsuarioID { get; set; } 
        public Pessoa Pessoa { get; set; }
        public List<Ficha> Ficha { get; set; }
        public Horario Horario { get; set; }


        public int PerfilID { get; set; }
        public string Perfil { get; set; }
    }
}
