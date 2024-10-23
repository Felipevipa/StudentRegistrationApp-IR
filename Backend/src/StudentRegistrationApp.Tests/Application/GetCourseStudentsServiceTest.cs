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
    public class GetCourseStudentsServiceTest
    {
        private readonly Mock<IStudentAndCoursesRepository> studentAndCoursesRepositoryMock = new Mock<IStudentAndCoursesRepository>();
        private readonly GetCourseStudentsService getCourseStudentsService;

        public GetCourseStudentsServiceTest()
        {
            getCourseStudentsService = new GetCourseStudentsService(studentAndCoursesRepositoryMock.Object);
        }

        [Fact]
        void GivenACourse_GetStudents_ListOfStudents()
        {
            // Arrange
            Teacher TEST_TEACHER_1 = new Teacher("José Perez");
            Course TEST_COURSE = new Course("Historia clásica 1", 3, TEST_TEACHER_1);
            Student TEST_STUDENT_1 = new Student("Andres Villamizar");
            Student TEST_STUDENT_2 = new Student("Antonio Villamizar");
            Student TEST_STUDENT_3 = new Student("Julian Villamizar");
            Student TEST_STUDENT_4 = new Student("José Villamizar");
            Student TEST_STUDENT_5 = new Student("German Villamizar");
            List<Enrollment> ENROLLMENTS_TEST = new List<Enrollment>();
            ENROLLMENTS_TEST.Add(new Enrollment(TEST_STUDENT_1, TEST_COURSE));
            ENROLLMENTS_TEST.Add(new Enrollment(TEST_STUDENT_2, TEST_COURSE));
            ENROLLMENTS_TEST.Add(new Enrollment(TEST_STUDENT_3, TEST_COURSE));
            ENROLLMENTS_TEST.Add(new Enrollment(TEST_STUDENT_4, TEST_COURSE));
            ENROLLMENTS_TEST.Add(new Enrollment(TEST_STUDENT_5, TEST_COURSE));

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetEnrollmentsOfCourse(TEST_COURSE.Id))
                .Returns(ENROLLMENTS_TEST);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetStudentById(TEST_STUDENT_1.Id))
                .Returns(TEST_STUDENT_1);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetStudentById(TEST_STUDENT_2.Id))
                .Returns(TEST_STUDENT_2);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetStudentById(TEST_STUDENT_3.Id))
                .Returns(TEST_STUDENT_3);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetStudentById(TEST_STUDENT_4.Id))
                .Returns(TEST_STUDENT_4);

            studentAndCoursesRepositoryMock
                .Setup(repo => repo.GetStudentById(TEST_STUDENT_5.Id))
                .Returns(TEST_STUDENT_5);


            // Act
            var studentsInCourse = getCourseStudentsService.Execute(TEST_COURSE);


            // Assert
            studentsInCourse.Should().HaveCount(5);
            studentsInCourse[0].Should().Be(TEST_STUDENT_1);
            studentsInCourse[1].Should().Be(TEST_STUDENT_2);
            studentsInCourse[2].Should().Be(TEST_STUDENT_3);
            studentsInCourse[3].Should().Be(TEST_STUDENT_4);
            studentsInCourse[4].Should().Be(TEST_STUDENT_5);

        }
    }
}
