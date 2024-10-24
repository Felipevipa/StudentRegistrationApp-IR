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
    public class RegisterStudentAndEnrollmentsService : IRegisterStudentAndEnrollments
    {
        private readonly IStudentAndCoursesRepository _studentsAndCoursesRepository;

        public RegisterStudentAndEnrollmentsService(IStudentAndCoursesRepository studentsAndCoursesRepository)
        {
            _studentsAndCoursesRepository = studentsAndCoursesRepository;
        }

        public Student Execute(string name, List<Course> courses)
        {
            ArgumentNullException.ThrowIfNull(name, "'name' must no be null");
            ArgumentNullException.ThrowIfNull(courses, "'courses' must no be null");
            if(courses.Count != 3)
            {
                throw new ArgumentException("There should be 3 courses registered");
            }
            var dupes = courses.GroupBy(x => new { x.TeacherId })
                               .Where(x => x.Skip(1).Any());
            if (dupes.Any())
            {
                throw new ArgumentException("You must register three courses with three different teachers");
            }
            Student student = _studentsAndCoursesRepository.CreateStudent(name);
            foreach (var course in courses)
            {
                _studentsAndCoursesRepository.CreateEnrollment(student, course);
            }
            return student;
        }
    }
}
