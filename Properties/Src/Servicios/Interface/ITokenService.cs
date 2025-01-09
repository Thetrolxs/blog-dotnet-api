using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.Entities;

namespace blog_dotnet_api.Properties.Src.Servicios.Interface
{
    public interface ITokenService
    {
        public string GenerateTokenAsync(User user);
    }
}