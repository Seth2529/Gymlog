using Gymlog.WebApp.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace Gymlog.WebApp.Models
{
    public class HorarioViewModel
    {
        public int HorarioID { get; set; }

        [Required(ErrorMessage = "Coloque a data do feriado")]
        [DisplayFormat(NullDisplayText = "Coloque a data do feriado")]
        [IdadeValidation(1, ErrorMessage = "Coloque a data correta para o proximo feriado.")]
        public DateTime? DataFeriado { get; set; }
        [Required(ErrorMessage = "Digite o dia da semana")]
        public string DiaDaSemana { get; set; }
        [Required(ErrorMessage = "Digite o horário de funcionamento")]
        public string HorarioPadrao { get; set; }
    }
}
