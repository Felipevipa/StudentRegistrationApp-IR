using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentRegistrationApp.Domain.Entities;

namespace StudentRegistrationApp.Application.Ports.In
{
    public interface IGetCoursesOfStudent
    {
        List<Course> Execute(StudentId studentId);
        List<Course> Execute (Student student);
    }
}
