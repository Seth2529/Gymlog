using System;
using System.ComponentModel.DataAnnotations;

namespace Gymlog.WebApp.Models.Validation
{
    public class IdadeValidation : ValidationAttribute
    {
        private readonly int _maxAge;

        public IdadeValidation(int maxAge)
        {
            _maxAge = maxAge;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var dateOfBirth = (DateTime)value;
                var age = DateTime.Today.Year - dateOfBirth.Year;

                if (age > _maxAge)
                {
                    return new ValidationResult($"A idade máxima permitida é de {_maxAge} anos.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
