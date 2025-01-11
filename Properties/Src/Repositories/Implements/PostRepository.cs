using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.Data;
using blog_dotnet_api.Properties.Src.Entities;
using blog_dotnet_api.Properties.Src.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace blog_dotnet_api.Properties.Src.Repositories.Implements
{
    public class PostRepository : IPostRepository
    {
        private readonly DataContext _context;

        public PostRepository(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<Post> AddPost(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            var posts = await _context.Posts.Include(u => u.User).ToListAsync();
            return posts;
        }
    }
}