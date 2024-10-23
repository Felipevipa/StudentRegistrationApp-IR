using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Application.Ports.In;
using StudentRegistrationApp.Application.Ports.Out.Persistence;

namespace StudentRegistrationApp.Application.Services
{
    public class GetCourseStudentsService : IGetCourseStudents
    {
        private readonly IStudentAndCoursesRepository _studentsAndCoursesRepository;

        public GetCourseStudentsService(IStudentAndCoursesRepository studentsAndCoursesRepository)
        {
            _studentsAndCoursesRepository = studentsAndCoursesRepository;
        }

        public List<Student> Execute(CourseId courseId)
        {
            ArgumentNullException.ThrowIfNull(courseId, "'courseId' must no be null");
            List<Enrollment> enrollments = _studentsAndCoursesRepository.GetEnrollmentsOfCourse(courseId);
            List<Student> students = enrollments.Select(enrollment =>
                _studentsAndCoursesRepository.GetStudentById(enrollment.Student.Id)).ToList();

            return students;
        }
        public List<Student> Execute(Course course)
        {
            ArgumentNullException.ThrowIfNull(course, "'course' must no be null");
            return Execute(course.Id);
        }
    }
}
