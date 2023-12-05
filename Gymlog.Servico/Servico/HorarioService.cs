using Gymlog.Dominio.Entidade;
using Gymlog.Dominio.IRepository;
using Gymlog.Dominio.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Servico.Servico
{
    public class HorarioService : IHorarioService
    {
        IHorarioRepository _horarioRepository;
        public HorarioService(IHorarioRepository repository)
        {
            _horarioRepository = repository;
        }
        public void CadastrarHorario(Horario horario)
        {
            var id = _horarioRepository.EncontrarProximoIDDisponivel();
            horario.HorarioID = id;
            _horarioRepository.CadastrarHorario(horario);
        }
        public void EditarHorario(Horario horario)
        {
            _horarioRepository.EditarHorario(horario);
        }
        public void ApagarHorario(int horarioID)
        {
            _horarioRepository.ApagarHorario(horarioID);
        }
        public IEnumerable<Horario> GetAll()
        {
            return _horarioRepository.GetAll();
        }

        public Horario GetOneById(int horarioID)
        {
            return _horarioRepository.GetOneById(horarioID);
        }
    }
}