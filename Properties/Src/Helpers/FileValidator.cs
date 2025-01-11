using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blog_dotnet_api.Properties.Src.Helpers
{
    public class FileValidator : ValidationAttribute
    {
        private readonly string[] ValidFormats = { "image/jpeg", "image/png", ".jpg", ".png"};
        private readonly long MaxSize = 5 * 1024 * 1024;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if(!ValidFormats.Contains(file.ContentType))
                {
                    throw new Exception("Formato de la imagen no válido. Solo JPG y PNG");
                }

                if(file.Length > MaxSize)
                {
                    throw new Exception("El tamaño de la imagen no puede superar los 5 MB");
                }
            }

            return ValidationResult.Success;
        }
    }
}