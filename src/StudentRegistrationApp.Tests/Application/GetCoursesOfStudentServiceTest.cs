using FluentAssertions;
using Moq;
using StudentRegistrationApp.Application.Ports.Out.Persistence;
using StudentRegistrationApp.Application.Services;
using StudentRegistrationApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationApp.Tests.Application
{
    public class GetCoursesOfStudentServiceTest
    {
        private readonly Mock<IStudentAndCoursesRepository> studentAndCoursesRepositoryMock = new Mock<IStudentAndCoursesRepository>();
        private readonly GetCoursesOfStudentService getCoursesOfStudentService;

        public GetCoursesOfStudentServiceTest()
        {
            getCoursesOfStudentService = new GetCoursesOfStudentService(studentAndCoursesRepositoryMock.Object);
        }

        [Fact]
        void GivenAnStudent_GetCourses_ListOfCourses()
        {
            // Arrange
            Student TEST_STUDENT = new Student("Andres Villamizar");
            Teacher TEST_TEACHER = new Teacher("Antonio Perez");
            Course TEST_COURSE_1 = new Course("Historia clásica 1", 3, TEST_TEACHER);
            Course TEST_COURSE_2 = new Course("Historia clásica 2", 3, TEST_TEACHER);
            Course TEST_COURSE_3 = new Course("Historia clásica 3", 3, TEST_TEACHER);
            List<Enrollment> ENROLLMENTS_TEST = new List<Enrollment>();
            ENROLLMENTS_TEST.Add(new Enrollment(TEST_STUDENT, TEST_COURSE_1));
            ENROLLMENTS_TEST.Add(new Enrollment(TEST_STUDENT, TEST_COURSE_2));
            ENROLLMENTS_TEST.Add(new Enrollment(TEST_STUDENT, TEST_COURSE_3));

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetEnrollmentsOfStudent(TEST_STUDENT.Id))
                .Returns(ENROLLMENTS_TEST);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetCourseById(TEST_COURSE_1.Id))
                .Returns(TEST_COURSE_1);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetCourseById(TEST_COURSE_2.Id))
                .Returns(TEST_COURSE_2);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetCourseById(TEST_COURSE_3.Id))
                .Returns(TEST_COURSE_3);


            // Act
            var coursesStudent = getCoursesOfStudentService.Execute(TEST_STUDENT.Id);


            // Assert
            coursesStudent.Should().HaveCount(3);
            coursesStudent[0].Teacher.Should().Be(TEST_TEACHER);
            coursesStudent[1].Teacher.Should().Be(TEST_TEACHER);
            coursesStudent[2].Teacher.Should().Be(TEST_TEACHER);
            coursesStudent[0].Should().Be(TEST_COURSE_1);
            coursesStudent[1].Should().Be(TEST_COURSE_2);
            coursesStudent[2].Should().Be(TEST_COURSE_3);

        }

    }
}
