using StudentRegistrationApp.Application.Services;
using StudentRegistrationApp.Application.Ports.In;
using StudentRegistrationApp.Application.Ports.Out.Persistence;
using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.MySqlDB;
using StudentRegistrationApp.Presentation.Api;

string CORSOpenPolicy = "OpenCORSPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(
      name: CORSOpenPolicy,
      builder => {
          builder.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
      });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StudentRegistrationDbContextPresentation>(options =>
{ options.UseSqlServer("name=DefaultConnection"); });

builder.Services.AddSingleton<IStudentAndCoursesRepository, InMemoryStudentAndCoursesRepository>();
builder.Services.AddScoped<IRegisterStudentAndEnrollments, RegisterStudentAndEnrollmentsService>();
builder.Services.AddScoped<IGetAllCourses, GetAllCoursesService>();
builder.Services.AddScoped<IGetCourseStudents, GetCourseStudentsService>();
builder.Services.AddScoped<IGetCoursesOfStudent, GetCoursesOfStudentService>();
builder.Services.AddScoped<IGetCoursesByTeacher, GetCoursesByTeacherService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(CORSOpenPolicy);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapGet("/health/instance", () =>
{
    return Results.Ok();
});


app.Run();
