using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Application.Ports.Out.Persistence
{
    public interface IStudentAndCoursesRepository
    {
        List<Enrollment> GetEnrollmentsOfStudent(Guid studentId);
        List<Enrollment> GetEnrollmentsOfStudent(Student student);
        Course GetCourseOfEnrollment(Guid courseId);
        Course GetCourseById(Guid courseId);

        List<Enrollment> GetEnrollmentsOfCourse(Guid courseId);
        List<Enrollment> GetEnrollmentsOfCourse(Course course);

        Student GetStudentById(Guid studentId);

        List<Student> GetStudentsOfEnrollment(Guid courseId);
        List<Student> GetStudentsOfEnrollment(Course course);

        List<Student> GetStudentsFromCourse(Course course);

        List<Course> GetCoursesByTeacher(Guid teacherId);
        List<Course> GetCoursesByTeacher(Teacher teacher);

        List<Course> GetAllCourses();

        Student CreateStudent(string name);

        Enrollment CreateEnrollment(Student student, Course course);
    }
}
