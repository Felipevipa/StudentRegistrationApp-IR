using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Teacher
    {
        public Guid TeacherId { get; set; }
        public string Name { get; set; }

        public Teacher()
        {
        }

        public Teacher(string name)
        {
            TeacherId = Guid.NewGuid();
            Name = name;
        }

        public Teacher(Guid teacherId, string name)
        {
            TeacherId = teacherId;
            Name = name;
        }
    }
}
