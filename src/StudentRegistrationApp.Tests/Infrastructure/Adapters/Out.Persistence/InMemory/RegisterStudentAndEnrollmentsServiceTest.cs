using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

using StudentRegistrationApp.Application.Services;
using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory;

namespace StudentRegistrationApp.Tests.Infrastructure.Adapters.Out.Persistence.InMemory
{
    public class RegisterStudentAndEnrollmentsServiceTest
    {
        private readonly InMemoryStudentAndCoursesRepository _repository;
        private readonly RegisterStudentAndEnrollmentsService _service;

        public RegisterStudentAndEnrollmentsServiceTest()
        {
            _repository = new InMemoryStudentAndCoursesRepository();
            _service = new RegisterStudentAndEnrollmentsService(_repository);
        }

        [Fact]
        public void GivenAnStudentRequest_RegisterThreeCourses_Success()
        {
            // Arrange
            string nameOfStudent = "Andres Villamizar";
            List<Course> coursesToRegister = new List<Course>
        {
            new Course(new CourseId(), "Math 101", 3, new Teacher(new TeacherId(), "Teacher 1")),
            new Course(new CourseId(), "History 101", 3, new Teacher(new TeacherId(), "Teacher 2")),
            new Course(new CourseId(), "Science 101", 3, new Teacher(new TeacherId(), "Teacher 3"))
        };

            // Act
            var student = _service.Execute(nameOfStudent, coursesToRegister);

            // Assert
            student.Should().NotBeNull();
            student.Name.Should().Be(nameOfStudent);
            
            var enrollments = _repository.GetEnrollmentsOfStudent(student.Id);
            enrollments.Should().HaveCount(3);

            enrollments.Should().Contain(e => e.Course.Name == "Math 101");
            enrollments.Should().Contain(e => e.Course.Name == "History 101");
            enrollments.Should().Contain(e => e.Course.Name == "Science 101");
        }
    }
}
