using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Application.Ports.Out.Persistence;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory
{
    public class InMemoryStudentAndCoursesRepository : IStudentAndCoursesRepository
    {
        private readonly List<Student> _students = new List<Student>();
        private readonly List<Course> _courses = new List<Course>();
        private readonly List<Teacher> _teachers = new List<Teacher>();
        private readonly List<Enrollment> _enrollments = new List<Enrollment>();
        public InMemoryStudentAndCoursesRepository()
        {
            // Add some default Teachers, Courses, and Students for testing
            var teacher1 = new Teacher(Guid.Parse("c8bff21b-0332-4d84-81a7-3941c18f1cc4"), "Julio Fernandez");
            var teacher2 = new Teacher(Guid.Parse("3fc255e6-d2f7-47f1-9b79-35ebf03dd7d4"), "Andres Villamizar");
            var teacher3 = new Teacher(Guid.Parse("9a16ab75-45f2-41f3-b918-4e4bbae71ee5"), "Luisa Torres");
            var teacher4 = new Teacher(Guid.Parse("812b7a9f-0c52-4717-b145-b5be80eed88d"), "Fernanda Salinas");
            var teacher5 = new Teacher(Guid.Parse("f7f5fc7a-8061-48ca-9486-85adc6e0ed97"), "Martin Hernandez");

            _teachers.Add(teacher1);
            _teachers.Add(teacher2);
            _teachers.Add(teacher3);
            _teachers.Add(teacher4);
            _teachers.Add(teacher5);

            _courses.Add(new Course(Guid.Parse("17119498-8bf9-4068-a5cf-dab7ddb55cd9"), "Historia 1", 3, teacher1));
            _courses.Add(new Course(Guid.Parse("be1d7182-1893-4f2a-b795-a8402398e605"), "Historia 2", 3, teacher1));
            _courses.Add(new Course(Guid.Parse("93c08df5-3d32-495b-a470-e481b685a4a7"), "Matematicas 1", 3, teacher2));
            _courses.Add(new Course(Guid.Parse("f1752182-ed9b-4115-9ba4-a5bf9db62838"), "Matematicas 2", 3, teacher2));
            _courses.Add(new Course(Guid.Parse("a53ba00f-c330-4e4b-9d23-824f325b5f27"), "Etica", 3, teacher3));
            _courses.Add(new Course(Guid.Parse("3e940134-4079-443e-b36a-da7319303f93"), "Catedra universitaria", 3, teacher3));
            _courses.Add(new Course(Guid.Parse("34cef1d4-b471-499d-969d-7747dfe057c4"), "Fisica 1", 3, teacher4));
            _courses.Add(new Course(Guid.Parse("4a7f2c46-774b-41d9-8e6d-becc29a20a72"), "Fisica 2", 3, teacher4));
            _courses.Add(new Course(Guid.Parse("c04348ed-e25a-4aae-a5b1-e0b497aafe15"), "Quimica 1", 3, teacher5));
            _courses.Add(new Course(Guid.Parse("508be8aa-ec1a-460d-84ac-3013e1ab43ed"), "Quimica 2", 3, teacher5));
        }

        public Enrollment CreateEnrollment(Student student, Course course)
        {
            Enrollment enrollment = new Enrollment(student, course);
            _enrollments.Add(enrollment);
            return enrollment;
        }

        public Student CreateStudent(string name)
        {
            Student student = new Student(name);
            _students.Add(student);
            return student;
        }

        public List<Course> GetAllCourses()
        {
            return _courses;
        }

        public Course GetCourseById(Guid courseId)
        {
            var course = _courses.FirstOrDefault(c => c.CourseId == courseId);
            if (course == null)
            {
                throw new InvalidOperationException($"Course with ID {courseId} not found.");
            }
            return course;
        }

        public Course GetCourseOfEnrollment(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCoursesByTeacher(Guid teacherId)
        {
            return _courses.Where(c => c.Teacher.TeacherId == teacherId).ToList();
        }

        public List<Course> GetCoursesByTeacher(Teacher teacher)
        {
            return GetCoursesByTeacher(teacher.TeacherId);
        }

        public List<Enrollment> GetEnrollmentsOfCourse(Guid courseId)
        {
            return _enrollments.Where(e => e.Course.CourseId == courseId).ToList();
        }

        public List<Enrollment> GetEnrollmentsOfCourse(Course course)
        {
            return GetEnrollmentsOfCourse(course.CourseId);
        }

        public List<Enrollment> GetEnrollmentsOfStudent(Guid studentId)
        {
            return _enrollments.Where(e => e.Student.StudentId == studentId).ToList();
        }

        public List<Enrollment> GetEnrollmentsOfStudent(Student student)
        {
            return GetEnrollmentsOfCourse(student.StudentId);
        }

        public Student GetStudentById(Guid studentId)
        {
            var student = _students.FirstOrDefault(c => c.StudentId == studentId);
            if (student == null)
            {
                throw new InvalidOperationException($"Course with ID {studentId} not found.");
            }
            return student;
        }

        public List<Student> GetStudentsFromCourse(Course course)
        {
            return _enrollments
               .Where(e => e.Course == course)
               .Select(e => e.Student)
               .ToList();
        }

        public List<Student> GetStudentsOfEnrollment(Guid courseId)
        {
            return _enrollments
                .Where(e => e.Course.CourseId == courseId)
                .Select(e => e.Student)
                .ToList();
        }

        public List<Student> GetStudentsOfEnrollment(Course course)
        {
            return GetStudentsOfEnrollment(course.CourseId);
        }
    }
}
