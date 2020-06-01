using Hippologamus.Server.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Hippologamus.Server.Validation
{
    public class MustMatch : ValidationAttribute
    {
        public MustMatch(string otherProperty)
        {
            this.otherProperty = otherProperty;
        }

        public string otherProperty;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance;
            var otherPropertyValue = GetProperty.Value(model, otherProperty);

            if (otherPropertyValue.Equals(value))
            {
                return ValidationResult.Success;
            }
            var memberDisplayName = GetDisplayNameAttribute.Value(model, validationContext.MemberName);
            var otherPropertyDisplayName = GetDisplayNameAttribute.Value(model, otherProperty);
            return new ValidationResult($"{memberDisplayName} must match {otherPropertyDisplayName}.");
        }
    }
}