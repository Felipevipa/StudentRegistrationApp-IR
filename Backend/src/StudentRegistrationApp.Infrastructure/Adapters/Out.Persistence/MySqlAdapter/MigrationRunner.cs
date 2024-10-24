using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.MySqlAdapter
{
    public class MigrationRunner
    {
        public static void RunMigrations(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<StudentsRegisterDbContext>();
                context.Database.Migrate();
            }
        }
    }
}
