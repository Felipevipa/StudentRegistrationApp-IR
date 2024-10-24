using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;

using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.Sql
{
    public class StudentRegistrationDbContext : DbContext
    {

        //public StudentRegistrationDbContext(DbContextOptions<StudentRegistrationDbContext> options)
        //: base(options)
        //{}
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=studentregistration;user=root;password=password");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Course>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Enrollment>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(c => c.Teacher)
                .WithMany()
                .HasForeignKey(c => c.TeacherId);

            // Apply Value Converters
            modelBuilder.Entity<Course>()
                .Property(c => c.Id)
                .HasConversion(new CourseIdConverter());

            modelBuilder.Entity<Student>()
                .Property(s => s.Id)
                .HasConversion(new StudentIdConverter());

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Id)
                .HasConversion(new EnrollmentIdConverter());

            modelBuilder.Entity<Teacher>()
                .Property(t => t.Id)
                .HasConversion(new TeacherIdConverter());

            modelBuilder.Entity<Teacher>().HasData(
                new Teacher("John Doe"),
                new Teacher("Jane Smith")
            );
        }
    }
}
