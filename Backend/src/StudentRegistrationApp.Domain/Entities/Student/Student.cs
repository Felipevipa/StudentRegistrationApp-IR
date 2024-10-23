using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Student
    {
        public StudentId Id { get; }
        public string Name { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

        public Student(StudentId id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            Id = id;
            Name = name;
        }

        public Student(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            Id = new StudentId();
            Name = name;
        }



        //public void EnrollInCourse(Course course)
        //{
        //    // Checking if the student has space for enroll in a new course and if he/she is not already enrolled in the course
        //    if (Courses.Count >= 3)
        //        throw new NotEnoughSpaceForCourseException();
        //    else if(!Courses.Contains(course))
        //        throw new AlreadyEnrolledInThisCourseException();
        //    Courses.Add(course);
        //}
    }
}
