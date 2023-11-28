using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gymlog.Dominio.Validation
{
    public class IdadeValidation : ValidationAttribute
    {
        private readonly int _Idade;

        public IdadeValidation(int Idade)
        {
            _Idade = Idade;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime dataNascimento = (DateTime)value;
                int idade = DateTime.Today.Year - dataNascimento.Year;

                if (idade > _Idade)
                {
                    return new ValidationResult($"A idade máxima permitida é {_Idade} anos.");
                }
            }

            return ValidationResult.Success;
        }
    }

}
