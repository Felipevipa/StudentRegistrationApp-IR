using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Application.Services;
using StudentRegistrationApp.Application.Ports.Out.Persistence;

namespace StudentRegistrationApp.Tests.Application
{
    public class GetAllCoursesServiceTest
    {
        private readonly Mock<IStudentAndCoursesRepository> studentAndCoursesRepositoryMock = new Mock<IStudentAndCoursesRepository>();
        private readonly GetAllCoursesService getAllCoursesService;

        public GetAllCoursesServiceTest()
        {
            getAllCoursesService = new GetAllCoursesService(studentAndCoursesRepositoryMock.Object);
        }

        [Fact]
        void AListOfCourses_GetCourses_ListOfCourses()
        {
            // Arrange
            Teacher TEST_TEACHER_1 = new Teacher("Antonio Perez");
            Teacher TEST_TEACHER_2 = new Teacher("Julian Rodriguez");
            Course TEST_COURSE_1 = new Course("Historia clásica 1", 3, TEST_TEACHER_1);
            Course TEST_COURSE_2 = new Course("Historia clásica 2", 3, TEST_TEACHER_1);
            Course TEST_COURSE_3 = new Course("Historia clásica 3", 3, TEST_TEACHER_2);
            Course TEST_COURSE_4 = new Course("Etica", 3, TEST_TEACHER_2);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetAllCourses())
                .Returns([TEST_COURSE_1, TEST_COURSE_2, TEST_COURSE_3, TEST_COURSE_4]);


            // Act
            var courses = getAllCoursesService.Execute();


            // Assert
            courses.Should().BeOfType<List<Course>>();
            courses[0].Should().BeOfType<Course>();
            courses.Should().HaveCount(4);

        }
    }
}
