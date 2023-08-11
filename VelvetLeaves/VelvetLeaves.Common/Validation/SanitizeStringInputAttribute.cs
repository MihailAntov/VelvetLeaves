﻿

using Ganss.Xss;
using System.ComponentModel.DataAnnotations;

namespace VelvetLeaves.Common.Validation
{
    public class SanitizeStringInputAttribute : ValidationAttribute
    {
        private readonly IHtmlSanitizer _sanitizer;
        public SanitizeStringInputAttribute()
        {
            _sanitizer = new HtmlSanitizer();
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null && value is string inputValue)
            {
                // Sanitize the input using the third-party library
                string sanitizedValue = _sanitizer.Sanitize(inputValue);

                // Update the model with the sanitized value
                if(validationContext != null)
                {
                var propertyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName!);
                    if(propertyInfo != null)
                    {
                        propertyInfo.SetValue(validationContext.ObjectInstance, sanitizedValue);

                    }
                }
                
                
            }

            // Always return success since we have updated the value
            return ValidationResult.Success!;
        }
    }
}
