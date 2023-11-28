using Gymlog.Dominio.Entidade;
using Gymlog.WebApp.Models.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace Gymlog.WebApp.Models
{
    public class PessoaViewModel
    {
        public int PessoaID { get; set; }

        [Required(ErrorMessage = "Digite seu nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite seu email")]
        [EmailAddress(ErrorMessage = "Email informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite sua cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Coloque a sua data de nascimento")]
        [DisplayFormat(NullDisplayText = "Coloque a sua data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Required(ErrorMessage = "Digite seu CPF")]
        [CPFValidation(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite sua senha")]
        public string Senha { get; set; }

        [Range(1,2)]
        public int PerfilID { get; set; }
    }
}
