using kolokwium2_przyklad.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Services;

public interface IEnrollmentService
{
    public Task<IEnumerable<EnrollmentDto>> GetEnrollment();
}
public class EnrollmentService(AppDbContext context) : IEnrollmentService
{
    public async Task<IEnumerable<EnrollmentDto>> GetEnrollment()
    {

        var enrollments = await context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToListAsync();

        return enrollments.Select(e => new EnrollmentDto
        {
            Student = new StudentDto
            {
                Id = e.Student.ID,
                FirstName = e.Student.FirstName,
                LastName = e.Student.LastName,
                Email = e.Student.Email
            },
            Course = new CourseDto
            {
                Id = e.Course.ID,
                Title = e.Course.Title,
                Credits = e.Course.Credits,
                Teacher = e.Course.Teacher
            },
            EnrollmentDate = e.EnrollmentDate
        }).ToList();
    }
}