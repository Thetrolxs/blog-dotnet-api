using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blog_dotnet_api.Properties.Src.DTOs
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set;} = string.Empty;

        [Required]
        public string Password { get; set;} = string.Empty;
    }
}