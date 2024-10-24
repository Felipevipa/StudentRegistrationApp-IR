using Microsoft.AspNetCore.Mvc;
using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Application.Ports.In;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegistrationApp.Presentation.Controllers
{
    [Route("courses/[controller]")]
    [ApiController]
    public class GetAllCoursesController : ControllerBase
    {
        private readonly IGetAllCourses _getAllCoursesService;

        public GetAllCoursesController(IGetAllCourses getAllCoursesService)
        {
            _getAllCoursesService = getAllCoursesService;
        }

        [HttpGet]
        public List<Course> Get()
        {
            return _getAllCoursesService.Execute();
            //return new string[] { "value1", "value2" };
        }
    }
}
