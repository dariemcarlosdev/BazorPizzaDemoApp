using System.ComponentModel.DataAnnotations;

namespace BlazingPizzaNavigation.Model
{
    public class PostalCodeAttribute : ValidationAttribute
    {
        public string GetErrorMessage() => $"Sorry, that's not a valid postal code.";      

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            if ((string)value != "postal")
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}