using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Course
    {
        public CourseId Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; } = 3;
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
