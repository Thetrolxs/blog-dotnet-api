using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.DTOs;
using blog_dotnet_api.Properties.Src.Entities;
using blog_dotnet_api.Properties.Src.Repositories.Implements;
using blog_dotnet_api.Properties.Src.Repositories.Interface;
using blog_dotnet_api.Properties.Src.Servicios.Interface;
using CloudinaryDotNet;

namespace blog_dotnet_api.Properties.Src.Servicios.Implements
{
    public class PostService : IPostService
    {

        private readonly IPostRepository _postRepository;
        private readonly IPhotoService _photoService;

        public PostService(IPostRepository postRepository, IPhotoService photoService)
        {
            _postRepository = postRepository;
            _photoService = photoService;
        }

        public async Task<Post> AddPostAsync(CreatePostDto createPostDto, string userId)
        {
            var result = await _photoService.AddPhoto(createPostDto.Image);

            if(result.Error != null)
            {
                throw new Exception("Error al subir la imagen");
            }

            var post = new Post
            {
                Title = createPostDto.Title,
                PublishedDate = DateTime.Now,
                ImageUrl = result.SecureUrl.AbsoluteUri,
                UserId = int.Parse(userId)
            };

            await _postRepository.AddPost(post);

            return post;
        }

        public async Task<IEnumerable<Post>> GetPostsAsync()
        {
            return await _postRepository.GetPostsAsync();
        }
    }
}