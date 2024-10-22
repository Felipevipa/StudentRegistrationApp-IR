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
        private readonly RegisterStudentAndEnrollmentsService _registerStudentAndEnrollmentsService;
        private readonly GetCourseStudentsService _getCourseStudentsService;
        private readonly GetCoursesOfStudentService _getCoursesOfStudentService;
        private readonly GetAllCoursesService _getAllCoursesService;
        private readonly GetCoursesByTeacherService _getCoursesByTeacherService;

        public RegisterStudentAndEnrollmentsServiceTest()
        {
            _repository = new InMemoryStudentAndCoursesRepository();
            _registerStudentAndEnrollmentsService = new RegisterStudentAndEnrollmentsService(_repository);
            _getCourseStudentsService = new GetCourseStudentsService(_repository);
            _getCoursesOfStudentService = new GetCoursesOfStudentService(_repository);
            _getAllCoursesService = new GetAllCoursesService(_repository);
            _getCoursesByTeacherService = new GetCoursesByTeacherService(_repository);
        }

        [Fact]
        public void GivenAnStudentRequest_RegisterThreeCourses_Success()
        {
            // Arrange
            string nameOfStudent = "Andres Villamizar";
            List<Course> coursesToRegister = new List<Course>
            {
                new Course(new CourseId(), "Ondas y Fisica Moderna", 3, new Teacher(new TeacherId(), "Teacher 1")),
                new Course(new CourseId(), "Filosofia", 3, new Teacher(new TeacherId(), "Teacher 2")),
                new Course(new CourseId(), "Ciencia 1", 3, new Teacher(new TeacherId(), "Teacher 3"))
            };

            // Act
            var student = _registerStudentAndEnrollmentsService.Execute(nameOfStudent, coursesToRegister);

            // Assert
            student.Should().NotBeNull();
            student.Name.Should().Be(nameOfStudent);
            
            var enrollments = _repository.GetEnrollmentsOfStudent(student.Id);
            enrollments.Should().HaveCount(3);

            enrollments.Should().Contain(e => e.Course.Name == "Ondas y Fisica Moderna");
            enrollments.Should().Contain(e => e.Course.Name == "Filosofia");
            enrollments.Should().Contain(e => e.Course.Name == "Ciencia 1");
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
            var act = () => _registerStudentAndEnrollmentsService.Execute(nameOfStudent, COURSES_TEST);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("There should be 3 courses registered");

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

            // Act
            var act = () => _registerStudentAndEnrollmentsService.Execute(nameOfStudent, COURSES_TEST);

            // Assert
            act.Should().Throw<ArgumentException>()
                .WithMessage("You must register three courses with three different teachers");
        }

        [Fact]
        void GivenACourse_GetStudents_ListOfStudents()
        {
            // Arrange
            Teacher TEST_TEACHER_1 = new Teacher("José Perez");
            Course TEST_COURSE_1 = new Course("Historia clásica 1", 3, TEST_TEACHER_1);
            Course TEST_COURSE_2 = new Course("Historia clásica 2", 3, new Teacher("Any name"));
            Course TEST_COURSE_3 = new Course("Historia clásica 3", 3, new Teacher("Any name"));
            List<Course> TEST_COURSE_LIST = new List<Course>();
            TEST_COURSE_LIST.Add(TEST_COURSE_1);
            TEST_COURSE_LIST.Add(TEST_COURSE_2);
            TEST_COURSE_LIST.Add(TEST_COURSE_3);


            _registerStudentAndEnrollmentsService.Execute("Andres Villamizar", TEST_COURSE_LIST);
            _registerStudentAndEnrollmentsService.Execute("Antonio Villamizar", TEST_COURSE_LIST);
            _registerStudentAndEnrollmentsService.Execute("Julian Villamizar", TEST_COURSE_LIST);
            _registerStudentAndEnrollmentsService.Execute("José Villamizar", TEST_COURSE_LIST);
            _registerStudentAndEnrollmentsService.Execute("German Villamizar", TEST_COURSE_LIST);

            // Act
            var studentsInCourse = _getCourseStudentsService.Execute(TEST_COURSE_1);


            // Assert
            studentsInCourse.Should().HaveCount(5);
            studentsInCourse[0].Name.Should().Be("Andres Villamizar");
            studentsInCourse[1].Name.Should().Be("Antonio Villamizar");
            studentsInCourse[2].Name.Should().Be("Julian Villamizar");
            studentsInCourse[3].Name.Should().Be("José Villamizar");
            studentsInCourse[4].Name.Should().Be("German Villamizar");

        }


        [Fact]
        void GivenAnStudent_GetCourses_ListOfCourses()
        {
            // Arrange
            List<Course> TEST_COURSE_LIST = _getAllCoursesService.Execute().GroupBy(x => x.TeacherId).Select(x => x.First()).ToList().Take(3).ToList();
            Student STUDENT_TEST = _registerStudentAndEnrollmentsService.Execute("Andres Villamizar", TEST_COURSE_LIST);

            // Act
            var coursesStudent = _getCoursesOfStudentService.Execute(STUDENT_TEST);


            // Assert
            coursesStudent.Should().HaveCount(3);
            TEST_COURSE_LIST[0].TeacherId.Should().Be(TEST_COURSE_LIST[0].TeacherId);
            TEST_COURSE_LIST[1].TeacherId.Should().Be(TEST_COURSE_LIST[1].TeacherId);
            TEST_COURSE_LIST[2].TeacherId.Should().Be(TEST_COURSE_LIST[2].TeacherId);
            coursesStudent[0].Should().Be(TEST_COURSE_LIST[0]);
            coursesStudent[1].Should().Be(TEST_COURSE_LIST[1]);
            coursesStudent[2].Should().Be(TEST_COURSE_LIST[2]);

        }

    }
}
