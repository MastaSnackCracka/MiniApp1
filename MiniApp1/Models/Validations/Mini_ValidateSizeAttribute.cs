using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace MiniApp1.Models.Validations
{
    public class MiniValidateSizeAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var mini = validationContext.ObjectInstance as Mini;
            if (mini != null)
            {
                if (mini.Size < 1 || mini.Size > 6)
                {
                    return new ValidationResult("The size has to be between 1 and 6");
                }

            }
            return ValidationResult.Success;
        }
    }
}
