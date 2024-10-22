﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Application.Ports.In
{
    public interface IGetCourseStudents
    {
        List<Student> Execute(CourseId courseId);
        List<Student> Execute(Course course);
    }
}
