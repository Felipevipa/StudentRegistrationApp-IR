using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class CourseId
    {
        public Guid Id { get; set; }

        public CourseId()
        {
            Id = Guid.NewGuid();
        }
    }
}
