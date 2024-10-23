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
    public class GetCoursesOfStudentService : IGetCoursesOfStudent
    {
        private readonly IStudentAndCoursesRepository _studentsAndCoursesRepository;

        public GetCoursesOfStudentService(IStudentAndCoursesRepository studentsAndCoursesRepository)
        {
            _studentsAndCoursesRepository = studentsAndCoursesRepository;
        }

        public List<Course> Execute(StudentId studentId)
        {
            ArgumentNullException.ThrowIfNull(studentId, "'studentId' must no be null");
            List<Enrollment> enrollments = _studentsAndCoursesRepository.GetEnrollmentsOfStudent(studentId);
            List<Course> courses = new List<Course>();
            foreach (var enrollment in enrollments)
            {
                courses.Add(_studentsAndCoursesRepository.GetCourseById(enrollment.CourseId));
            }

            return courses;
        }

        public List<Course> Execute(Student student)
        {
            ArgumentNullException.ThrowIfNull(student, "'student' must no be null");
            return Execute(student.Id);
        }

    }
}
