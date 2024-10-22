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

            Student student = _studentsAndCoursesRepository.CreateStudent(new Student(name));
            foreach (var course in courses)
            {
                _studentsAndCoursesRepository.CrateEnrollment(new Enrollment(student, course));
            }
            return student;
        }
    }
}
