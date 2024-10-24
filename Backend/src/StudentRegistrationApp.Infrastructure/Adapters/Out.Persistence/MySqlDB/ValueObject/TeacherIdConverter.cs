using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using StudentRegistrationApp.Domain.Entities;
public class TeacherIdConverter : ValueConverter<TeacherId, Guid>
{
    public TeacherIdConverter() : base(
        id => id.Id,
        guid => new TeacherId(guid))
    {
    }
}