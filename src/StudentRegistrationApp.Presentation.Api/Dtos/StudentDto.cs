using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Presentation.Api.Dtos
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<EnrollmentDto> Enrollments { get; set; }
    }
}
