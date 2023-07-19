using Microsoft.EntityFrameworkCore;
using WebUserApi.Entities;

namespace WebUserApi.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<User> Users { get; set; }

        public DataContext( IConfiguration configuration )
        {
            Configuration = configuration;
            Users = Set<User>();
        }

        protected override void OnConfiguring( DbContextOptionsBuilder options )
        {
            options.UseInMemoryDatabase( "TestDb" );
        }
    }
}
