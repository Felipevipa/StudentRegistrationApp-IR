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
            var teacher1 = new Teacher(new TeacherId(), "Julio Fernandez");
            var teacher2 = new Teacher(new TeacherId(), "Andres Villamizar");
            var teacher3 = new Teacher(new TeacherId(), "Luisa Torres");
            var teacher4 = new Teacher(new TeacherId(), "Fernanda Salinas");
            var teacher5 = new Teacher(new TeacherId(), "Martin Hernandez");

            _teachers.Add(teacher1);
            _teachers.Add(teacher2);
            _teachers.Add(teacher3);
            _teachers.Add(teacher4);
            _teachers.Add(teacher5);

            _courses.Add(new Course(new CourseId(), "Historia 1", 3, teacher1));
            _courses.Add(new Course(new CourseId(), "Historia 2", 3, teacher1));
            _courses.Add(new Course(new CourseId(), "Matematicas 1", 3, teacher2));
            _courses.Add(new Course(new CourseId(), "Matematicas 2", 3, teacher2));
            _courses.Add(new Course(new CourseId(), "Etica", 3, teacher3));
            _courses.Add(new Course(new CourseId(), "Catedra universitaria", 3, teacher3));
            _courses.Add(new Course(new CourseId(), "Fisica 1", 3, teacher4));
            _courses.Add(new Course(new CourseId(), "Fisica 2", 3, teacher4));
            _courses.Add(new Course(new CourseId(), "Quimica 1", 3, teacher5));
            _courses.Add(new Course(new CourseId(), "Quimica 2", 3, teacher5));
        }

        public Enrollment CreateEnrollment(Enrollment enrollment)
        {
            _enrollments.Add(enrollment);
            return enrollment;
        }

        public Student CreateStudent(Student student)
        {
            _students.Add(student);
            return student;
        }

        public List<Course> GetAllCourses()
        {
            return _courses;
        }

        public Course GetCourseById(CourseId courseId)
        {
            return _courses.FirstOrDefault(c => c.Id == courseId); ;
        }

        public Course GetCourseOfEnrollment(CourseId courseId)
        {
            throw new NotImplementedException();
        }

        public List<Course> GetCoursesByTeacher(TeacherId teacherId)
        {
            return _courses.Where(c => c.Teacher.Id == teacherId).ToList();
        }

        public List<Course> GetCoursesByTeacher(Teacher teacher)
        {
            return GetCoursesByTeacher(teacher.Id);
        }

        public List<Enrollment> GetEnrollmentsOfCourse(CourseId courseId)
        {
            return _enrollments.Where(e => e.Course.Id == courseId).ToList();
        }

        public List<Enrollment> GetEnrollmentsOfCourse(Course course)
        {
            return _enrollments.Where(e => e.Course == course).ToList();
        }

        public List<Enrollment> GetEnrollmentsOfStudent(StudentId studentId)
        {
            return _enrollments.Where(e => e.Student.Id == studentId).ToList();
        }

        public List<Enrollment> GetEnrollmentsOfStudent(Student student)
        {
            return _enrollments.Where(e => e.Student == student).ToList();
        }

        public Student GetStudentById(StudentId studentId)
        {
            return _students.FirstOrDefault(s => s.Id == studentId);
        }

        public List<Student> GetStudentsFromCourse(Course course)
        {
            return _enrollments
               .Where(e => e.Course == course)
               .Select(e => e.Student)
               .ToList();
        }

        public List<Student> GetStudentsOfEnrollment(CourseId courseId)
        {
            return _enrollments
                .Where(e => e.Course.Id == courseId)
                .Select(e => e.Student)
                .ToList();
        }

        public List<Student> GetStudentsOfEnrollment(Course course)
        {
            return _enrollments
                .Where(e => e.Course == course)
                .Select(e => e.Student)
                .ToList();
        }
    }
}
