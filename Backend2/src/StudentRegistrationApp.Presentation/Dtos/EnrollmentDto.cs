﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Presentation.Dtos
{
    public class EnrollmentDto
    {
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
