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
    public class GetCourseByTeacherServiceTest
    {


        private readonly Mock<IStudentAndCoursesRepository> studentAndCoursesRepositoryMock = new Mock<IStudentAndCoursesRepository>();
        private readonly GetCoursesByTeacherService getCoursesByTeacherService;

        public GetCourseByTeacherServiceTest()
        {
            getCoursesByTeacherService = new GetCoursesByTeacherService(studentAndCoursesRepositoryMock.Object);
        }

        [Fact]
        void GivenCoursesCreatedAndTeacherId_GetCourses_ListOfCourses()
        {
            // Arrange
            Teacher TEST_TEACHER_1 = new Teacher("Antonio Perez");
            Teacher TEST_TEACHER_2 = new Teacher("Julian Rodriguez");
            Course TEST_COURSE_1 = new Course("Historia clásica 1", 3, TEST_TEACHER_1);
            Course TEST_COURSE_2 = new Course("Historia clásica 2", 3, TEST_TEACHER_1);
            Course TEST_COURSE_3 = new Course("Historia clásica 3", 3, TEST_TEACHER_2);
            Course TEST_COURSE_4= new Course("Etica", 3, TEST_TEACHER_2);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetCoursesByTeacher(TEST_TEACHER_1.Id))
                .Returns([TEST_COURSE_1, TEST_COURSE_2]);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetCoursesByTeacher(TEST_TEACHER_2.Id))
                .Returns([TEST_COURSE_3, TEST_COURSE_4]);


            // Act
            var coursesTeacher1 = getCoursesByTeacherService.Execute(TEST_TEACHER_1.Id);
            var coursesTeacher2 = getCoursesByTeacherService.Execute(TEST_TEACHER_2);


            // Assert
            coursesTeacher1.Should().HaveCount(2);
            coursesTeacher1[0].Teacher.Should().Be(TEST_TEACHER_1);
            coursesTeacher1[1].Teacher.Should().Be(TEST_TEACHER_1);
            coursesTeacher2.Should().HaveCount(2);
            coursesTeacher2[0].Teacher.Should().Be(TEST_TEACHER_2);
            coursesTeacher2[1].Teacher.Should().Be(TEST_TEACHER_2);

        }
    }
}
