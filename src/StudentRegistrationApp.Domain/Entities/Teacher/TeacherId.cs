using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class TeacherId
    {
        public Guid Id { get; set; }

        public TeacherId()
        {
            Id = Guid.NewGuid();
        }
    }
}
