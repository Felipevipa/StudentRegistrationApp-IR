using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Presentation
{
    public class StudentsRegisterDbContext : DbContext
    {
        public StudentsRegisterDbContext(DbContextOptions options) : base(options)
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

            // Seeding Teachers
            modelBuilder.Entity<Teacher>().HasData(
                new Teacher(Guid.Parse("c8bff21b-0332-4d84-81a7-3941c18f1cc4"), "Julio Fernandez"),
                new Teacher(Guid.Parse("3fc255e6-d2f7-47f1-9b79-35ebf03dd7d4"), "Andres Villamizar"),
                new Teacher(Guid.Parse("9a16ab75-45f2-41f3-b918-4e4bbae71ee5"), "Luisa Torres"),
                new Teacher(Guid.Parse("812b7a9f-0c52-4717-b145-b5be80eed88d"), "Fernanda Salinas"),
                new Teacher(Guid.Parse("f7f5fc7a-8061-48ca-9486-85adc6e0ed97"), "Martin Hernandez")
            );

            // Seeding Courses
            modelBuilder.Entity<Course>().HasData(
                new { CourseId = Guid.Parse("17119498-8bf9-4068-a5cf-dab7ddb55cd9"), Name = "Historia 1", Credits = 3, TeacherId = Guid.Parse("c8bff21b-0332-4d84-81a7-3941c18f1cc4") },
                new { CourseId = Guid.Parse("be1d7182-1893-4f2a-b795-a8402398e605"), Name = "Historia 2", Credits = 3, TeacherId = Guid.Parse("c8bff21b-0332-4d84-81a7-3941c18f1cc4") },
                new { CourseId = Guid.Parse("93c08df5-3d32-495b-a470-e481b685a4a7"), Name = "Matematicas 1", Credits = 3, TeacherId = Guid.Parse("3fc255e6-d2f7-47f1-9b79-35ebf03dd7d4") },
                new { CourseId = Guid.Parse("f1752182-ed9b-4115-9ba4-a5bf9db62838"), Name = "Matematicas 2", Credits = 3, TeacherId = Guid.Parse("3fc255e6-d2f7-47f1-9b79-35ebf03dd7d4") },
                new { CourseId = Guid.Parse("a53ba00f-c330-4e4b-9d23-824f325b5f27"), Name = "Etica", Credits = 3, TeacherId = Guid.Parse("9a16ab75-45f2-41f3-b918-4e4bbae71ee5") },
                new { CourseId = Guid.Parse("3e940134-4079-443e-b36a-da7319303f93"), Name = "Catedra universitaria", Credits = 3, TeacherId = Guid.Parse("9a16ab75-45f2-41f3-b918-4e4bbae71ee5") },
                new { CourseId = Guid.Parse("34cef1d4-b471-499d-969d-7747dfe057c4"), Name = "Fisica 1", Credits = 3, TeacherId = Guid.Parse("812b7a9f-0c52-4717-b145-b5be80eed88d") },
                new { CourseId = Guid.Parse("4a7f2c46-774b-41d9-8e6d-becc29a20a72"), Name = "Fisica 2", Credits = 3, TeacherId = Guid.Parse("812b7a9f-0c52-4717-b145-b5be80eed88d") },
                new { CourseId = Guid.Parse("c04348ed-e25a-4aae-a5b1-e0b497aafe15"), Name = "Quimica 1", Credits = 3, TeacherId = Guid.Parse("f7f5fc7a-8061-48ca-9486-85adc6e0ed97") },
                new { CourseId = Guid.Parse("508be8aa-ec1a-460d-84ac-3013e1ab43ed"), Name = "Quimica 2", Credits = 3, TeacherId = Guid.Parse("f7f5fc7a-8061-48ca-9486-85adc6e0ed97") }
            );
        }

    }
}
