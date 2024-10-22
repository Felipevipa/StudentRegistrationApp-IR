using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Enrollment
    {
        public EnrollmentId Id { get; set; }

        public StudentId StudentId { get; set; }
        public Student Student { get; set; }

        public CourseId CourseId { get; set; }
        public Course Course { get; set; }

        public Enrollment(Student student, Course course)
        {
            Id = new EnrollmentId();
            StudentId = student.Id;
            Student = student;
            CourseId = course.Id;
            Course = course;
        }

        public Enrollment(EnrollmentId id, Student student, Course course)
        {
            Id = id;
            StudentId = student.Id;
            Student = student;
            CourseId = course.Id;
            Course = course;
        }
    }
}
