using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Presentation.Api.Dtos
{
    public class RegisterStudentDto
    {
        public string StudentName { get; set; }
        public List<CourseDto> Courses { get; set; }
    }
}
