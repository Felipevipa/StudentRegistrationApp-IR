using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory.Mappers
{
    public class StudentMapper
    {
        public StudentDto ToDto(Student student)
        {
            return new StudentDto
            {
                Id = student.StudentId,
                Name = student.Name
            };
        }

        public Student ToEntity(StudentDto studentDto)
        {
            return new Student(studentDto.Id, studentDto.Name);
        }
    }
}
