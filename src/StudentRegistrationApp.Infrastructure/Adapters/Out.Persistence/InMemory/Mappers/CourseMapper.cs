using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Dtos;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Mappers
{
    public class CourseMapper
    {
        private readonly TeacherMapper _teacherMapper = new TeacherMapper();

        public CourseDto ToDto(Course course)
        {
            return new CourseDto
            {
                Id = course.Id.Id,
                Name = course.Name,
                Credits = course.Credits,
                Teacher = _teacherMapper.ToDto(course.Teacher)
            };
        }

        public Course ToEntity(CourseDto courseDto)
        {
            return new Course(
                new CourseId(courseDto.Id),
                courseDto.Name,
                courseDto.Credits,
                _teacherMapper.ToEntity(courseDto.Teacher)
                );
        }
    }
}
