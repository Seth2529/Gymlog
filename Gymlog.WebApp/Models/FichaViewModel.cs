using Gymlog.Dominio.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace Gymlog.WebApp.Models
{
    public class FichaViewModel
    {

        public int FichaID { get; set; }

        [Required(ErrorMessage = "Digite o nome da ficha")]
        public string NomeFicha { get; set; }

        [Required(ErrorMessage = "Escreva as observações")]
        public string Observacoes { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de semanas para usar essa ficha")]
        public int QuantidadeSemanas { get; set; }


        [Required(ErrorMessage = "Digite a qual pessoa pertence")]
        public int PessoaID { get; set; }
    }
}
