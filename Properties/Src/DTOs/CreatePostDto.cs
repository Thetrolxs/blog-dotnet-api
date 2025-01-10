using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.Helpers;

namespace blog_dotnet_api.Properties.Src.DTOs
{
    public class CreatePostDto
    {
        [Required]
        [MinLength(5, ErrorMessage ="El título debe tener al menos 5 caracteres.")]
        public string Title {get; set;} = string.Empty;
        
        [FileValidator]
        public IFormFile Image {get; set;} = null!;
    }
}