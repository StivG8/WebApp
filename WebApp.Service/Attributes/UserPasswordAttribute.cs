using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Service.Attributes
{
    public class UserPasswordAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string password &&
                password.Length >= 8 &&
                password.Any(c => char.IsDigit(c)) &&
                password.Any(c => char.IsLetter(c)) &&
                password.Any(c => char.IsSymbol(c)))
                return ValidationResult.Success;
            return new ValidationResult("Password should contain at least 8 character, " +
                "1 letter, 1 digit, 1 symbol");
        }
    }
}