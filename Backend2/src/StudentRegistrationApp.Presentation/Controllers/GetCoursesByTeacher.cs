using Microsoft.AspNetCore.Mvc;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Application.Ports.In;

namespace StudentRegistrationApp.Presentation.Controllers
{
    [Route("courses/[controller]")]
    [ApiController]
    public class GetCoursesByTeacher : ControllerBase
    {
        private readonly IGetCoursesByTeacher _getCoursesByTeacher;

        public GetCoursesByTeacher(IGetCoursesByTeacher getCoursesByTeacher)
        {
            _getCoursesByTeacher = getCoursesByTeacher;
        }

        [HttpGet("{id}")]
        public List<Course> Get(Guid id)
        {
            return _getCoursesByTeacher.Execute(id);
        }
    }
}
