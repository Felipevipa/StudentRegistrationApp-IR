using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistrationApp.Application.Ports.Out.Persistence;
using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.MySql.Repositories
{
    public class StudentAndCoursesRepository : IStudentAndCoursesRepository
    {
        private readonly string _connectionString;

        public StudentAndCoursesRepository(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException(nameof(connectionString));

            _connectionString = connectionString;
        }

        public Enrollment CreateEnrollment(Enrollment enrollment)
        {
            //using (var connection = CreateConnection())
            //{

            //}
            throw new NotImplementedException();
        }

        public Student CreateStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetAllCourses()
        {
            throw new NotImplementedException();
        }

        public Course GetCourseById(CourseId courseId)
        {
            throw new NotImplementedException();
        }

        public Course GetCourseOfEnrollment(CourseId courseId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCoursesByTeacher(TeacherId teacherId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCoursesByTeacher(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public List<Enrollment> GetEnrollmentsOfCourse(CourseId courseId)
        {
            throw new NotImplementedException();
        }

        public List<Enrollment> GetEnrollmentsOfCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public List<Enrollment> GetEnrollmentsOfStudent(StudentId studentId)
        {
            throw new NotImplementedException();
        }

        public List<Enrollment> GetEnrollmentsOfStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(StudentId studentId)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsFromCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsOfEnrollment(CourseId courseId)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsOfEnrollment(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
