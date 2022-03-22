using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schronisko.Entities;

namespace Schronisko.Database
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {
            
        }
        
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Dog> Dogs { get; set; }
        
        
    }
}