using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Presentation.Api.Dtos
{
    public class EnrollmentDto
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }
    }
}
