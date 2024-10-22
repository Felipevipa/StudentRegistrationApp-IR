using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Course
    {
        public CourseId Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; } = 3;
        public TeacherId TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public Course(string name, int credits, Teacher teacher)
        {
            Id = new CourseId();
            Name = name;
            Credits = credits;
            TeacherId = teacher.Id;
            Teacher = teacher;
        }
    }
}
