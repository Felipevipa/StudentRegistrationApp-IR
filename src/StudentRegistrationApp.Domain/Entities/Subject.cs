using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class Subject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
