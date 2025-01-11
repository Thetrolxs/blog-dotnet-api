using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.DTOs;

namespace blog_dotnet_api.Properties.Src.Servicios.Interface
{
    public interface IAuthService
    {
        Task<TokenDto> Login(LoginDto loginDto);
        Task<TokenDto> Register(RegisterDto registerDto);
    }
}