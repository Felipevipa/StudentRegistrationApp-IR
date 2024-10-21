using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define relationships
        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Student)
            .WithMany(s => s.Enrollments)
            .HasForeignKey(e => e.StudentId);

        modelBuilder.Entity<Enrollment>()
            .HasOne(e => e.Course)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.CourseId);

        // Seed Professors and Courses (Predefined data)
        modelBuilder.Entity<Professor>().HasData(
            new Professor { Id = 1, Name = "Professor A" },
            new Professor { Id = 2, Name = "Professor B" },
            new Professor { Id = 3, Name = "Professor C" },
            new Professor { Id = 4, Name = "Professor D" },
            new Professor { Id = 5, Name = "Professor E" }
        );

        modelBuilder.Entity<Course>().HasData(
            new Course { Id = 1, Name = "Math", ProfessorId = 1 },
            new Course { Id = 2, Name = "Physics", ProfessorId = 1 },
            new Course { Id = 3, Name = "Chemistry", ProfessorId = 2 },
            new Course { Id = 4, Name = "Biology", ProfessorId = 2 },
            new Course { Id = 5, Name = "History", ProfessorId = 3 },
            new Course { Id = 6, Name = "Geography", ProfessorId = 3 },
            new Course { Id = 7, Name = "English", ProfessorId = 4 },
            new Course { Id = 8, Name = "Art", ProfessorId = 4 },
            new Course { Id = 9, Name = "Music", ProfessorId = 5 },
            new Course { Id = 10, Name = "PE", ProfessorId = 5 }
        );
    }
}

