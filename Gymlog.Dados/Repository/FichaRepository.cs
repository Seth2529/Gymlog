using Gymlog.Dados.EntityFramework;
using Gymlog.Dominio.IRepository;
using Gymlog.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dados.Repository
{
    public class FichaRepository : IFichaRepository
    {
        Contexto Contexto { get; set; }
        public FichaRepository(Contexto contexto) { Contexto = contexto; }

        public int EncontrarProximoIDDisponivel()
        {
            var idsExistentes = Contexto.Ficha.Select(p => p.FichaID).ToList();
            int proximoID = 1;

            while (idsExistentes.Contains(proximoID))
            {
                proximoID++;
            }

            return proximoID;
        }
        public void CadastrarFicha(Ficha ficha)
        {
            Contexto.Ficha.Add(ficha);
            Contexto.SaveChanges();
        }

        public void EditarFicha(Ficha ficha)
        {
            Contexto.Ficha.Update(ficha);
            Contexto.SaveChanges();
        }

        public void ApagarFicha(int fichaID)
        {
            var ficha = Contexto.Ficha.FirstOrDefault(p => p.FichaID.Equals(fichaID));
            if (ficha != null)
            {
                Contexto.Ficha.Remove(ficha);
                Contexto.SaveChanges();
            }
        }

        public Ficha GetOneById(int fichaID)
        {
            return Contexto.Ficha.First(e => e.FichaID == fichaID);
        }

        public IEnumerable<Ficha> GetAll()
        {
            return Contexto.Ficha.Where(p => true);
        }
    }
}