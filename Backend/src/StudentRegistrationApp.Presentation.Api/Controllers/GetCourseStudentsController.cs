using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegistrationApp.Application.Ports.In;
using StudentRegistrationApp.Application.Services;
using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Presentation.Api.Controllers
{
    [Route("enrollments/[controller]")]
    [ApiController]
    public class GetCourseStudentsController : ControllerBase
    {
        private readonly IGetCourseStudents _getCourseStudentsService;
        public GetCourseStudentsController(IGetCourseStudents getCourseStudents)
        {
            _getCourseStudentsService = getCourseStudents;
        }

        [HttpGet("{id}")]
        public List<Student> Get(Guid id)
        {
            return _getCourseStudentsService.Execute(new CourseId(id));
        }
    }


}
