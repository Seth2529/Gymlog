using Gymlog.WebApp.Models.Validation;
using System.ComponentModel.DataAnnotations;

namespace Gymlog.WebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Digite seu CPF")]
        [CPFValidation(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite sua senha")]
        public string Senha { get; set; }

        public void Autenticado() 
        {
            return;
        }
    }
}
