using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Application.Ports.Out.Persistence;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.MySqlAdapter.Repositories
{
    public class StudentAndCoursesRepository : IStudentAndCoursesRepository
    {
        private readonly StudentsRegisterDbContext _context;

        public StudentAndCoursesRepository(StudentsRegisterDbContext context)
        {
            _context = context;
        }

        public Enrollment CreateEnrollment(Student student, Course course)
        {
            var enrollment = new Enrollment(student, course);
            student.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return enrollment;
        }

        public Student CreateStudent(string name)
        {
            var student = new Student(name);
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses
                .Include(c => c.Teacher)
                .ToList();
        }

        public Course GetCourseById(Guid courseId)
        {
            var course = _context.Courses
                .Include(c => c.Teacher)
                .FirstOrDefault(c => c.CourseId == courseId);
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
            return _context.Courses
                .Where(c => c.Teacher.TeacherId == teacherId)
                .ToList();
        }

        public List<Course> GetCoursesByTeacher(Teacher teacher)
        {
            return GetCoursesByTeacher(teacher.TeacherId);
        }

        public List<Enrollment> GetEnrollmentsOfCourse(Guid courseId)
        {
            var course = _context.Courses
                .Include(c => c.Enrollments)
                    .ThenInclude(e => e.Student)
                .FirstOrDefault(c => c.CourseId == courseId);

            return course?.Enrollments.ToList() ?? new List<Enrollment>();
        }

        public List<Enrollment> GetEnrollmentsOfCourse(Course course)
        {
            return GetEnrollmentsOfCourse(course.CourseId);
        }

        public List<Enrollment> GetEnrollmentsOfStudent(Guid studentId)
        {
            var student = _context.Students
                .Include(s => s.Enrollments)
                    //.ThenInclude(e => e.Course)
                .FirstOrDefault(s => s.StudentId == studentId);

            return student?.Enrollments.ToList() ?? new List<Enrollment>();
        }

        public List<Enrollment> GetEnrollmentsOfStudent(Student student)
        {
            return GetEnrollmentsOfCourse(student.StudentId);
        }

        public Student GetStudentById(Guid studentId)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                throw new InvalidOperationException($"Student with ID {studentId} not found.");
            }
            return student;
        }

        public List<Student> GetStudentsFromCourse(Course course)
        {
            var courseWithEnrollments = _context.Courses
                .Include(c => c.Enrollments)
                    .ThenInclude(e => e.Student)
                .FirstOrDefault(c => c.CourseId == course.CourseId);

            return courseWithEnrollments?.Enrollments.Select(e => e.Student).ToList() ?? new List<Student>();
        }

        public List<Student> GetStudentsOfEnrollment(Guid courseId)
        {
            throw new NotImplementedException();
        }

        public List<Student> GetStudentsOfEnrollment(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
