using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApp.Service.Attributes
{
    public class UserEmailAttribute:ValidationAttribute
    {
        Regex emailValidation = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string email && emailValidation.IsMatch(email))
                return ValidationResult.Success;
            return new ValidationResult("Invalid Email address");
        }
    }
}
