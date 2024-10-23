using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Teacher
    {
        public TeacherId Id { get; set; }
        public string Name { get; set; }

        public Teacher(string name)
        {
            Id = new TeacherId();
            Name = name;
        }

        public Teacher(TeacherId teacherId, string name)
        {
            Id = teacherId;
            Name = name;
        }
    }
}
