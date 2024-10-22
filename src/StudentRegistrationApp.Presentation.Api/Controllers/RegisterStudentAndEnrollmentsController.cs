﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using StudentRegistrationApp.Domain.Entities;
using StudentRegistrationApp.Application.Ports.In;
using StudentRegistrationApp.Presentation.Api.Dtos;

namespace StudentRegistrationApp.Presentation.Api.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //[Produces("application/json")]
    public class RegisterStudentAndEnrollmentsController : ControllerBase
    {
        private readonly IRegisterStudentAndEnrollments _registerStudentAndEnrollmentsService;

        public RegisterStudentAndEnrollmentsController(IRegisterStudentAndEnrollments registerStudentAndEnrollments)
        {
            _registerStudentAndEnrollmentsService = registerStudentAndEnrollments;
        }



        [HttpPost("student/register")]
        public ActionResult RegisterStudentAndEnrollments([FromBody] RegisterStudentDto request)
        {
            if (request.Courses.Count != 3)
            {
                return BadRequest("Exactly 3 courses must be registered.");
            }

            var courses = request.Courses.Select(c => new Course(
                new CourseId(c.CourseId),
                c.CourseName,
                c.Credits,
                new Teacher(new TeacherId(), c.TeacherName)
            )).ToList();


            var student = _registerStudentAndEnrollmentsService.Execute(request.StudentName, courses);

            var studentDto = new StudentDto
            {
                Id = student.Id.Id,
                Name = student.Name
            };

            return Ok(studentDto);
        }
    }
}
