using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Enrollment
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public Enrollment()
        {
        }

        public Enrollment(Student student, Course course)
        {
            StudentId = student.StudentId;
            Student = student;
            CourseId = course.CourseId;
            Course = course;
        }

    }
}
