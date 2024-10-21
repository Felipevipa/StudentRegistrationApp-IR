using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Subject> subjects { get; set; }
    }
}
