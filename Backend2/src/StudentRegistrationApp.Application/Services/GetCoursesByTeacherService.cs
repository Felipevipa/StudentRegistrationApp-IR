using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentRegistrationApp.Application.Ports.In;
using StudentRegistrationApp.Application.Ports.Out.Persistence;
using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Application.Services
{
    public class GetCoursesByTeacherService : IGetCoursesByTeacher
    {
        private readonly IStudentAndCoursesRepository _studentsAndCoursesRepository;

        public GetCoursesByTeacherService(IStudentAndCoursesRepository studentsAndCoursesRepository)
        {
            _studentsAndCoursesRepository = studentsAndCoursesRepository;
        }
        public List<Course> Execute(Guid teacherId)
        {
            ArgumentNullException.ThrowIfNull(teacherId, "'teacherId' must no be null");

            List<Course> courses = _studentsAndCoursesRepository.GetCoursesByTeacher(teacherId);

            return courses;
        }

        public List<Course> Execute(Teacher teacher)
        {
            ArgumentNullException.ThrowIfNull(teacher, "'teacher' must no be null");

            return Execute(teacher.TeacherId);
        }

    }
}
