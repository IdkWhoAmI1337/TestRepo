public interface IEnrollmentService
{
    public Task<IEnumerable<EnrollmentDTO>> GetEnrollment();
}
public class EnrollmentService(AppDbContext context) : IEnrollmentService
{
    public async Task<IEnumerable<EnrollmentDTO>> GetEnrollment()
    {

        var enrollments = await context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .ToListAsync();

        return enrollments.Select(e => new EnrollmentDTO
        {
            Student = new StudentDTO
            {
                Id = e.Student.ID,
                FirstName = e.Student.FirstName,
                LastName = e.Student.LastName,
                Email = e.Student.Email
            },
            Course = new CourseDTO
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
 