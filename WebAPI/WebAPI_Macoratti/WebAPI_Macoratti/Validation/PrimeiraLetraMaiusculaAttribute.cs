using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICatalogo.Validation
{
    public class PrimeiraLetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            // Convertendo value para string, pegando o primeiro caractere e convertendo este valor para string novamente
            // para que seja possivel utilizar a função ToUpper()
            string primeiraLetra = value.ToString()[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
                return new ValidationResult("A primeira letra do nome do produto deve ser maiúscula");

            return ValidationResult.Success;
        }
    }
}
