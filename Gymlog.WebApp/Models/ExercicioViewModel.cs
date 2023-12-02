using Gymlog.WebApp.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace Gymlog.WebApp.Models
{
    public class ExercicioViewModel
    {

        public int ExercicioID { get; set; }

        [Required(ErrorMessage = "Digite o nome do Exercicio")]
        public string NomeExercicio { get; set; }


        [Required(ErrorMessage = "Escolha o Tipo de Repetição")]
        public int TipoRepeticaoID { get; set; }


        [Required(ErrorMessage = "Digite a quantidade de séries")]
        public int SerieExercicio { get; set; }
    }
}
