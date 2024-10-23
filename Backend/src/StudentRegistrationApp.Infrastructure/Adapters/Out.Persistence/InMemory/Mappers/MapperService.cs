using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Mappers
{
    public class MapperService
    {
        public TeacherMapper TeacherMapper { get; } = new TeacherMapper();
        public CourseMapper CourseMapper { get; } = new CourseMapper();
        public StudentMapper StudentMapper { get; } = new StudentMapper();
        public EnrollmentMapper EnrollmentMapper { get; } = new EnrollmentMapper();
    }
}
