using System.ComponentModel.DataAnnotations;

namespace Garage3.Validations
{
    public class NameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            const string errorMessage = "Firstname and lastname can not be the same";

            if ( value is string input)
            {
                var model = validationContext.ObjectInstance as MemberCreateViewModel;
                
                if (model != null)
                {
                    if (model.NameFirstName != input)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult(errorMessage);
                }
            }
            return new ValidationResult(errorMessage);
        }
    }
}
