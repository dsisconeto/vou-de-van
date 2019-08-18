using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Web.Support.Validations
{
    public class ImageValidation : ValidationAttribute
    {
        private readonly Dictionary<string, bool> _typeImageAllow = new Dictionary<string, bool>()
        {
            {"image/jpeg", true},
            {"image/png", true},
        };


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            switch (value)
            {
                case IFormFile form:
                    return ValidationSingle(form, validationContext);
                case IEnumerable<IFormFile> forms:
                    return ValidationEnumerable(forms, validationContext);
                default:
                    throw new ArgumentException("is not IFormFile or  IEnumerable<IFormFile");
            }
        }

        public ValidationResult ValidationSingle(IFormFile form, ValidationContext validationContext)
        {
            var isValid = _typeImageAllow.ContainsKey(form.ContentType);

            return isValid
                ? ValidationResult.Success
                : new ValidationResult($"O tipo do {validationContext.DisplayName} é inválido");
        }

        public ValidationResult ValidationEnumerable(IEnumerable<IFormFile> forms, ValidationContext validationContext)
        {
            var hasAnyInvalid = forms.Any(f => _typeImageAllow.ContainsKey(f.ContentType) == false);

            return hasAnyInvalid
                ? new ValidationResult($"O tipo do {validationContext.DisplayName} é inválido")
                : ValidationResult.Success;
        }
    }
}
