using DatabaseProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HospitalDbMigrations
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext( string[] args )
        {
            string connectionString =
                "Data Source=MILKYWAY\\SQLEXPRESS;Initial Catalog=Books;Pooling=true;Integrated Security=SSPI";
            var optionBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionBuilder.UseSqlServer( connectionString, assembly => assembly.MigrationsAssembly( "HospitalDbMigrations" ) );
            return new ApplicationContext( optionBuilder.Options );
        }
    }
}
