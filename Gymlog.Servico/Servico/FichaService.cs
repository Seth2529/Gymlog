using Gymlog.Dominio.IRepository;
using Gymlog.Dominio.IService;
using Gymlog.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Servico.Servico
{
    public class FichaService : IFichaService
    {
        IFichaRepository _FichaRepository;
        public FichaService(IFichaRepository repository)
        {
            _FichaRepository = repository;
        }
        public void CadastrarFicha(Ficha ficha)
        {
            var id = _FichaRepository.EncontrarProximoIDDisponivel();
            ficha.FichaID = id;
            _FichaRepository.CadastrarFicha(ficha);
        }
        public void EditarFicha(Ficha ficha)
        {
            _FichaRepository.EditarFicha(ficha);
        }
        public void ApagarFicha(int fichaID)
        {
            _FichaRepository.ApagarFicha(fichaID);
        }
        public IEnumerable<Ficha> GetAll()
        {
            return _FichaRepository.GetAll();
        }

        public Ficha GetOneById(int fichaID)
        {
            return _FichaRepository.GetOneById(fichaID);
        }
    }
}

