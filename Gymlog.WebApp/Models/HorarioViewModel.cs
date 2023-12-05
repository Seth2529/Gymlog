using Gymlog.WebApp.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace Gymlog.WebApp.Models
{
    public class HorarioViewModel
    {
        public int HorarioID { get; set; }

        [Required(ErrorMessage = "Coloque a sua data de nascimento")]
        [DisplayFormat(NullDisplayText = "Coloque a sua data de nascimento")]
        [IdadeValidation(90, ErrorMessage = "A idade máxima permitida é de 90 anos.")]
        public DateTime? DataFeriado { get; set; }
        [Required(ErrorMessage = "Digite o dia da semana")]
        public string DiaDaSemana { get; set; }
        [Required(ErrorMessage = "Digite o horário de funcionamento")]
        public string HorarioPadrao { get; set; }
    }
}
