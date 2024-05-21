using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BlazorPizzaDemoApp.Model
{
    public class PostalCodeAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"Sorry, that's not a valid postal code.";      

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
             var regex = new Regex(@"^([0-9]{5})$");
            if (!regex.IsMatch((string)value))
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}