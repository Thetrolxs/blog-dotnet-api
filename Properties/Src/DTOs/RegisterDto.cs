using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blog_dotnet_api.Properties.Src.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set;} = string.Empty;

        [Required]
        [MinLength(6, ErrorMessage = "La contraseña debe tener un minimo de 6 caracteres.")]
        [RegularExpression(@"^(?=.*\d).+$", ErrorMessage = "La contraseña debe tener al menos 1 número")]
        public string Password { get; set;} = string.Empty;

        [Compare("Password", ErrorMessage ="Las constraseñas no coinciden.")]
        public string confirmPassword {get; set;} = string.Empty;
    }
}