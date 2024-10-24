using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using StudentRegistrationApp.Domain.Entities;
public class StudentIdConverter : ValueConverter<StudentId, Guid>
{
    public StudentIdConverter() : base(
        id => id.Id,
        guid => new StudentId(guid))
    {
    }
}