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
    public class ExercicioService : IExercicioService
    {
        IExercicioRepository _exercicioRepository;
        public ExercicioService(IExercicioRepository repository)
        {
            _exercicioRepository = repository;
        }
        public void CadastrarExercicio(Exercicio exercicio)
        {
            var id = _exercicioRepository.EncontrarProximoIDDisponivel();
            exercicio.ExercicioID = id;
            _exercicioRepository.CadastrarExercicio(exercicio);
        }
        public void EditarExercicio(Exercicio Exercicio)
        {
            _exercicioRepository.EditarExercicio(Exercicio);
        }
        public void ApagarExercicio(int ExercicioID)
        {
            _exercicioRepository.ApagarExercicio(ExercicioID);
        }
        public IEnumerable<Exercicio> GetAll()
        {
            return _exercicioRepository.GetAll();
        }

        public Exercicio GetOneById(int ExercicioID)
        {
            return _exercicioRepository.GetOneById(ExercicioID);
        }
    }
}

