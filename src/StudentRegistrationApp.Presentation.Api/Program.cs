using StudentRegistrationApp.Application.Services;
using StudentRegistrationApp.Application.Ports.In;
using StudentRegistrationApp.Application.Ports.Out.Persistence;
using StudentRegistrationApp.Infrastructure.Adapters.Out.Persistence.InMemory;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRegisterStudentAndEnrollments, RegisterStudentAndEnrollmentsService>();
builder.Services.AddScoped<IStudentAndCoursesRepository, InMemoryStudentAndCoursesRepository>();
builder.Services.AddScoped<IGetAllCourses, GetAllCoursesService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapGet("/health/instance", () =>
{
    return Results.Ok();
});


app.Run();
