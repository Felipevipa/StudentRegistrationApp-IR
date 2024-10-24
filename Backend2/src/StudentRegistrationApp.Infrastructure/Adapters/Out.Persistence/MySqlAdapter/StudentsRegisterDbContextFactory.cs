using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.MySqlAdapter
{
 public class StudentsRegisterDbContextFactory : IDesignTimeDbContextFactory<StudentsRegisterDbContext>
    {
        public StudentsRegisterDbContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentsRegisterDbContext>();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Adapters/Out.Persistence/MySqlAdapter/appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            return new StudentsRegisterDbContext(optionsBuilder.Options);
        }
    }
}
