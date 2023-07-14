using DatabaseProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookingCarMigration
{
    public class ContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            string connectionString =
                "Data Source=LAPTOP-R69EMDDL\\SQLEXPRESS;Initial Catalog=BookingCar;Pooling=true;Integrated Security=SSPI";
            var optionalBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            optionalBuilder.UseSqlServer(connectionString,
                assembly => assembly.MigrationsAssembly("BookingCarMigration"));

            return new ApplicationContext(optionalBuilder.Options);
        }
    }
}
