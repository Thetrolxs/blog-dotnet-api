using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog_dotnet_api.Properties.Src.DTOs
{
    public class PostDto
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public string ImageUrl {get; set;} = null!;
        public DateTime PublishDate {get; set;} 
        public string Email {get; set;} = string.Empty;
    }
}