﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Domain.Entities
{
    public class StudentId
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
