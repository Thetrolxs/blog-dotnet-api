using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_dotnet_api.Properties.Src.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace blog_dotnet_api.Properties.Src.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options): base(options){}
        public DbSet<Post> Posts {get; set;} = null!;
    }
}