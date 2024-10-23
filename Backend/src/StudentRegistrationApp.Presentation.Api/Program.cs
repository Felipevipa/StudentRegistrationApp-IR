using StudentRegistrationApp.Application.Services;
using StudentRegistrationApp.Application.Ports.In;
using StudentRegistrationApp.Application.Ports.Out.Persistence;
using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "https://localhost:4200");
                      });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.UseCors(MyAllowSpecificOrigins);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapGet("/health/instance", () =>
{
    return Results.Ok();
});


app.Run();
