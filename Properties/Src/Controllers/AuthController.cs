using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.DTOs;
using blog_dotnet_api.Properties.Src.Servicios.Interface;
using Microsoft.AspNetCore.Mvc;

namespace blog_dotnet_api.Properties.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            try{
                var response = await _authService.Register(registerDto);
                return Ok(response);
            } catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            try{
                var response = await _authService.Login(loginDto);
                return Ok(response);
            } catch(Exception ex){
                return BadRequest(ex.Message);
            }
        }
    }
}