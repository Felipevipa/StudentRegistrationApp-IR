using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Course
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; } = 3;
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [JsonIgnore]
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public Course()
        {
        }

        public Course(string name, int credits, Teacher teacher)
        {
            CourseId = Guid.NewGuid();
            Name = name;
            Credits = credits;
            TeacherId = teacher.TeacherId;
            Teacher = teacher;
        }

        public Course(Guid id, string name, int credits, Teacher teacher)
        {
            CourseId = id;
            Name = name;
            Credits = credits;
            TeacherId = teacher.TeacherId;
            Teacher = teacher;
        }

        public Course(Guid id, string name, int credits, Guid teacherId)
        {
            CourseId = id;
            Name = name;
            Credits = credits;
            TeacherId = teacherId;
            Teacher = new Teacher(teacherId, "any name");
        }

    }
}
