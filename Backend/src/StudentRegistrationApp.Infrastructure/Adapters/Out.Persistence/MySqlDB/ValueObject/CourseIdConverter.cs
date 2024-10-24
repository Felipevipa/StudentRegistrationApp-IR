using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using StudentRegistrationApp.Domain.Entities;
public class CourseIdConverter : ValueConverter<CourseId, Guid>
{
    public CourseIdConverter() : base(
        id => id.Id, // Convert CourseId to Guid
        guid => new CourseId(guid)) // Convert Guid back to CourseId
    {
    }
}