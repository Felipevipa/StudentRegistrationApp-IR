using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Presentation.Dtos
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
    }
}
