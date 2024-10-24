using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.MySqlAdapter
{
    public class StudentsRegisterDbContextAdapter : DbContext
    {
        public StudentsRegisterDbContextAdapter(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>()
                .Property(s => s.StudentId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Course>()
                .Property(c => c.CourseId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Teacher>()
                .Property(t => t.TeacherId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Enrollment>()
                .HasKey(em => new { em.StudentId, em.CourseId });


            modelBuilder.Entity<Enrollment>()
                .HasOne(em => em.Student)
                .WithMany(e => e.Enrollments)
                .HasForeignKey(em => em.StudentId);


            modelBuilder.Entity<Enrollment>()
                .HasOne(em => em.Course)
                .WithMany(m => m.Enrollments)
                .HasForeignKey(em => em.CourseId);
        }

    }
}
