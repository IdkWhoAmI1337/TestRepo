namespace WebApplication1.Controllers;

public interface IEnrollmentService
{
    public Task<EnrollmentDTO> GetEnrollment();
}
public class EnrollmentService(AppDbContext context) : IEnrollmentService
{
    public async Task<EnrollmentDTO> GetEnrollment()
    {

        var enrollment = await context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .FirstOrDefaultAsync();

        if (enrollment == null)
        {
            return null;
        }

        return new EnrollmentDTO
        {
            Student = new StudentDTO
            {
                Id = enrollment.Student.ID,
                FirstName = enrollment.Student.FirstName,
                LastName = enrollment.Student.LastName,
                Email = enrollment.Student.Email
            },
            Course = new CourseDTO
            {
                Id = enrollment.Course.ID,
                Title = enrollment.Course.Title,
                Credits = enrollment.Course.Credits,
                Teacher = enrollment.Course.Teacher
            }
        };
    }
}