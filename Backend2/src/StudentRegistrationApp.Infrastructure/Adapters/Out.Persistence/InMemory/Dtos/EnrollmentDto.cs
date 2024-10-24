using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Dtos
{
    public class EnrollmentDto
    {
        public Guid Id { get; set; }
        public StudentDto Student { get; set; }
        public CourseDto Course { get; set; }
    }
}
