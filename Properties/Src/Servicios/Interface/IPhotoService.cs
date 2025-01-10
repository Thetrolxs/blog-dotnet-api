using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;

namespace blog_dotnet_api.Properties.Src.Servicios.Implements
{
    public interface IPhotoService
    {
        Task<ImageUploadResult> AddPhoto(IFormFile photo);
    }
}