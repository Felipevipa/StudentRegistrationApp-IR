using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Application.Services;
using StudentRegistrationApp.Application.Ports.In;
using StudentRegistrationApp.Application.Ports.Out.Persistence;
using FluentAssertions;

namespace StudentRegistrationApp.Tests.Application
{
    public class RegisterStudentAndEnrollmentsServiceTest
    {
        private readonly Mock<IStudentAndCoursesRepository> studentAndCoursesRepositoryMock = new Mock<IStudentAndCoursesRepository>();
        private readonly RegisterStudentAndEnrollmentsService registerStudentAndEnrollments;

        public RegisterStudentAndEnrollmentsServiceTest()
        {
            registerStudentAndEnrollments = new RegisterStudentAndEnrollmentsService(studentAndCoursesRepositoryMock.Object);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(25)]
        void GivenAnStudentRequest_RegisterMoreOrLessThanThreeCourses_ThrowsException(int numberOfCourses)
        {
            // Arrange
            string nameOfStudent = "Andres Villamizar";
            List<Course> COURSES_TEST = new List<Course>();

            for (int i = 0; i < numberOfCourses; i++)
            {
                Teacher NEW_TEACHER_TEST = new Teacher(i.ToString());
                COURSES_TEST.Add(new Course(i.ToString(), 3, NEW_TEACHER_TEST));
            }

            // Act
            var act = () => registerStudentAndEnrollments.Execute(nameOfStudent, COURSES_TEST);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("There should be 3 courses registered");

        }

        [Fact]
        void GivenAnStudentRequest_RegisterThreeCourses_Success()
        {
            // Arrange
            string nameOfStudent = "Andres Villamizar";
            Student STUDENT_TEST = new Student(nameOfStudent);
            List<Course> COURSES_TEST = new List<Course>();

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.CreateStudent(It.IsAny<Student>()))
                .Returns(STUDENT_TEST);

            for (int i = 0; i < 3; i++)
            {
                Teacher NEW_TEACHER_TEST = new Teacher(i.ToString());
                Course NEW_COURSE_TEST = new Course(i.ToString(), 3, NEW_TEACHER_TEST);
                COURSES_TEST.Add(NEW_COURSE_TEST);

            }

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.CreateEnrollment(It.IsAny<Enrollment>()))
                .Returns((Enrollment enrollment) => enrollment);



            // Act
            var act = () => registerStudentAndEnrollments.Execute(nameOfStudent, COURSES_TEST);

            // Assert
            act.Should().NotThrow();
        }

        [Fact]
        void GivenAnStudentRequest_RegisterThreeCoursesRepetingTeacher_ThrowsException()
        {
            // Arrange
            string nameOfStudent = "Andres Villamizar";
            Student STUDENT_TEST = new Student(nameOfStudent);
            List<Course> COURSES_TEST = new List<Course>();

            Teacher TEST_TEACHER_1 = new Teacher("Antonio Perez");
            Teacher TEST_TEACHER_2 = new Teacher("Julian Rodriguez");
            COURSES_TEST.Add(new Course("Historia clásica 1", 3, TEST_TEACHER_1));
            COURSES_TEST.Add(new Course("Historia clásica 2", 3, TEST_TEACHER_1));
            COURSES_TEST.Add(new Course("Historia clásica 3", 3, TEST_TEACHER_2));

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.CreateStudent(It.IsAny<Student>()))
                .Returns(STUDENT_TEST);


            studentAndCoursesRepositoryMock
                .Setup(repo => repo.CreateEnrollment(It.IsAny<Enrollment>()))
                .Returns((Enrollment enrollment) => enrollment);



            // Act
            var act = () => registerStudentAndEnrollments.Execute(nameOfStudent, COURSES_TEST);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("You must register three courses with three different teachers");
        }
    }
}
