using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Student
    {
        public Guid StudentId { get; }
        public string Name { get; set; }
        [JsonIgnore]
        public List<Enrollment> Enrollments { get; set; } = [];

        public Student()
        {
        }

        public Student(Guid id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));

            StudentId = id;
            Name = name;
        }

        public Student(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
            StudentId = Guid.NewGuid();
            Name = name;
        }
    }
}
