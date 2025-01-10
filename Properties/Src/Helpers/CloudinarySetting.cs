using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog_dotnet_api.Properties.Src.Helpers
{
    public class CloudinarySetting
    {
        public required string CloudName {get; set;}
        public required string ApiKey {get; set;}
        public required string ApiSecret {get; set;}
    }
}