using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Web.Support.Validations
{
    public class MaxFileSizeValidation : ValidationAttribute
    {
        private readonly long _sizeInKb;

        public MaxFileSizeValidation(long sizeInKB)
        {
            _sizeInKb = sizeInKB;
        }

        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            switch (value)
            {
                case IFormFile form:
                    return ValidateSingle(form, validationContext);
                case IEnumerable<IFormFile> forms:
                    return ValidateEnumerable(forms, validationContext);
                default:
                    throw new ArgumentException("Is not IFormFile");
            }
        }


        public ValidationResult ValidateSingle(IFormFile form, ValidationContext validationContext)
        {
            var lengthInKb = form.Length / 1024;

            return lengthInKb < _sizeInKb
                ? ValidationResult.Success
                : new ValidationResult($"O tamanho do arquivo do campo {validationContext.DisplayName} é inválido");
        }

        public ValidationResult ValidateEnumerable(IEnumerable<IFormFile> forms, ValidationContext validationContext)
        {
            var hasAnyInvalid = forms.Any(form => (form.Length / 1024) > _sizeInKb);

            return hasAnyInvalid
                ? ValidationResult.Success
                : new ValidationResult($"O tamanho do arquivo do campo {validationContext.DisplayName} é inválido");
        }
    }
}