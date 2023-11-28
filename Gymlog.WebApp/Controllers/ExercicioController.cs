//using Gymlog.Dominio.ValueObjects;
//using Microsoft.AspNetCore.Mvc;
//using Gymlog.Dados.EntityFramework;

//namespace Gymlog.WebApp.Controllers
//{
//    public class ExercicioController : Controller
//    {
//        private Contexto Db = new Contexto();

//        public IActionResult Index()
//        {
//            var resultado = Db.Exercicio
//                .ToList();

//            return View(resultado);
//        }

//        public IActionResult Inserir()
//        {
//            var ent = new Exercicio();
//            return View(ent);
//        }

//        [HttpPost]
//        public IActionResult InserirConfirmar(Exercicio ent)
//        {
//            int novoID = EncontrarProximoIDDisponivel();
//            ent.ExercicioID = novoID;
//            Db.Exercicio.Add(ent);
//            Db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        private int EncontrarProximoIDDisponivel()
//        {
//            var idsExistentes = Db.Pessoa.Select(p => p.PessoaID).ToList();
//            int proximoID = 1;

//            while (idsExistentes.Contains(proximoID))
//            {
//                proximoID++;
//            }

//            return proximoID;
//        }
//        public IActionResult Excluir(int exercicioId)
//        {
//            var objeto = Db
//                .Exercicio
//                .First(f => f.ExercicioID == exercicioId);

//            Db.Exercicio.Remove(objeto);
//            Db.SaveChanges();

//            return RedirectToAction("Index");
//        }

//    }

//}
