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
    public class GetAllCoursesService : IGetAllCourses
    {

        private readonly IStudentAndCoursesRepository _studentsAndCoursesRepository;

        public GetAllCoursesService(IStudentAndCoursesRepository studentsAndCoursesRepository)
        {
            _studentsAndCoursesRepository = studentsAndCoursesRepository;
        }
        public List<Course> Execute()
        {
            return _studentsAndCoursesRepository.GetAllCourses();
        }
    }
}
