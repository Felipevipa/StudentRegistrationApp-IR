using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Dtos;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Mappers
{
    public class TeacherMapper
    {
        public TeacherDto ToDto(Teacher teacher)
        {
            return new TeacherDto
            {
                Id = teacher.Id.Id,
                Name = teacher.Name
            };
        }

        public Teacher ToEntity(TeacherDto teacherDto) 
        {
            return new Teacher(new TeacherId(teacherDto.Id), teacherDto.Name);
        }
    }
}
