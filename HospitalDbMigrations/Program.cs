using Microsoft.EntityFrameworkCore;

namespace HospitalDbMigrations
{
    internal class Program
    {
        static void Main( string[] args )
        {
            new ContextFactory().CreateDbContext( args ).Database.Migrate();
        }
    }
}