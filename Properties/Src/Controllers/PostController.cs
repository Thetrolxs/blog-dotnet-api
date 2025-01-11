using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.DTOs;
using blog_dotnet_api.Properties.Src.Servicios.Implements;
using blog_dotnet_api.Properties.Src.Servicios.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog_dotnet_api.Properties.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPost()
        {
            var posts = await _postService.GetPostsAsync();
            return Ok(posts);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost([FromForm] CreatePostDto createPostDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try{
                var userId = User.FindFirst(ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("El usuario no está autenticado.");
                }
                var post = await _postService.AddPostAsync(createPostDto, userId);
                return Ok(post);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}