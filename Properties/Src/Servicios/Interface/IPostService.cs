using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.DTOs;
using blog_dotnet_api.Properties.Src.Entities;

namespace blog_dotnet_api.Properties.Src.Servicios.Interface
{
    public interface IPostService
    {
        public Task<IEnumerable<Post>> GetPostsAsync();
        public Task<Post> AddPostAsync(CreatePostDto createPostDto, string userId);
    }
}