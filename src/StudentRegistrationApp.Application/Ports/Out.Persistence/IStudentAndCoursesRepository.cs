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
        List<Enrollment> GetEnrollmentsOfStudent(StudentId studentId);
        List<Enrollment> GetEnrollmentsOfStudent(Student student);
        Course GetCourseOfEnrollment(CourseId courseId);
        Course GetCourseById(CourseId courseId);

        List<Enrollment> GetEnrollmentsOfCourse(CourseId courseId);
        List<Enrollment> GetEnrollmentsOfCourse(Course course);

        Student GetStudentById(StudentId studentId);

        List<Student> GetStudentsOfEnrollment(CourseId courseId);
        List<Student> GetStudentsOfEnrollment(Course course);

        List<Student> GetStudentsFromCourse(Course course);

        List<Course> GetCoursesByTeacher(TeacherId teacherId);
        List<Course> GetCoursesByTeacher(Teacher teacher);

        Student CreateStudent(Student student);

        Enrollment CrateEnrollment(Enrollment enrollment);
    }
}
