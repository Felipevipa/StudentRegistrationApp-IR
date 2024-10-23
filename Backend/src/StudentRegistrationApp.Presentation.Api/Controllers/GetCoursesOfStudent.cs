using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Application.Services;
using StudentRegistrationApp.Application.Ports.In;

namespace StudentRegistrationApp.Presentation.Api.Controllers
{
    [Route("enrollments/[controller]")]
    [ApiController]
    public class GetCoursesOfStudent : ControllerBase
    {
        private readonly IGetCoursesOfStudent _getCoursesOfStudent;

        public GetCoursesOfStudent(IGetCoursesOfStudent getCoursesOfStudent)
        {
            _getCoursesOfStudent = getCoursesOfStudent;
        }

        [HttpGet("{id}")]
        public List<Course> Get(Guid id)
        {
            return _getCoursesOfStudent.Execute(new StudentId(id));
        }
    }


}
