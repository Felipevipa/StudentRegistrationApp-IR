using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using StudentRegistrationApp.Domain.Entities;
public class EnrollmentIdConverter : ValueConverter<EnrollmentId, Guid>
{
    public EnrollmentIdConverter() : base(
        id => id.Id,
        guid => new EnrollmentId(guid))
    {
    }
}