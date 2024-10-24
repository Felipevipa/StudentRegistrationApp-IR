using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Mappers
{
    public class EnrollmentMapper
    {
        private readonly StudentMapper _studentMapper = new StudentMapper();
        private readonly CourseMapper _courseMapper = new CourseMapper();

        public EnrollmentDto ToDto(Enrollment enrollment)
        {
            return new EnrollmentDto
            {
                Student = _studentMapper.ToDto(enrollment.Student),
                Course = _courseMapper.ToDto(enrollment.Course)
            };
        }

        public Enrollment ToEntity(EnrollmentDto enrollmentDto)
        {
            return new Enrollment(
                _studentMapper.ToEntity(enrollmentDto.Student),
                _courseMapper.ToEntity(enrollmentDto.Course)
            );
        }
    }
}
