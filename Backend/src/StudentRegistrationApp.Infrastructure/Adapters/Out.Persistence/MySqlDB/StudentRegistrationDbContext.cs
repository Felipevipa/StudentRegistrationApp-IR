using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.MySqlDB
{
    public class StudentRegistrationDbContext : DbContext
    {

        public StudentRegistrationDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Course> Courses { get; set; }


    }
}
