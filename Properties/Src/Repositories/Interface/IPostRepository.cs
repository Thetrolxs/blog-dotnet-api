using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.Entities;

namespace blog_dotnet_api.Properties.Src.Repositories.Interface
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostsAsync();
        Task <Post>AddPost(Post post);
    }
}