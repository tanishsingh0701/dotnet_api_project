using dotnet_api_project.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_api_project.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<Character> Characters { get; set; }
        

        public DbSet<Player> Players { get; set; }

    }
}