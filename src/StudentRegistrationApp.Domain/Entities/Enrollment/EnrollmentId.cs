﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class EnrollmentId
    {
        public Guid Id { get; set; }

        public EnrollmentId()
        {
            Id = Guid.NewGuid();
        }

        public EnrollmentId(Guid id)
        {
            Id = id;
        }
    }
}
