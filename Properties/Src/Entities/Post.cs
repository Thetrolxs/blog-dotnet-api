using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog_dotnet_api.Properties.Src.Entities
{
    public class Post
    {
        public int Id {get; set;}
        public string Title {get; set;} = string.Empty;
        public DateTime PublishedDate {get; set;}
        public string ImageUrl {get; set;} = string.Empty;
        public string UserId {get; set;}
        public User User {get; set;}

    }
}