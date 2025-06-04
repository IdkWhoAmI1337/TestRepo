using kolokwium2_przyklad.Data;
using WebApplication1.DTOs;

namespace WebApplication1.Controllers;

public interface ICourseService
{
    Task<CourseResponseDto> CreateCourse(CourseRequestDto request);
}

public class CourseService(AppDbContext context) : ICourseService
{

    public async Task<CourseResponseDto> CreateCourse(CourseRequestDto request)
    {
        var course = new CourseDto
        {
            Title = request.Title,
            Credits = request.Credits,
            Teacher = request.Teacher
        };
        context.Courses.Add(course);
        await context.SaveChangesAsync();

        var enrollmentInfos = new List<EnrollmentStudentDto>();

        foreach (var studentDto in request.Students)
        {
            var student = await context.Students
                .FirstOrDefaultAsync(s =>
                    s.FirstName == studentDto.FirstName &&
                    s.LastName == studentDto.LastName &&
                    s.Email == studentDto.Email);

            if (student == null)
            {
                student = new StudentDto
                {
                    FirstName = studentDto.FirstName,
                    LastName = studentDto.LastName,
                    Email = studentDto.Email
                };
                context.Students.Add(student);
                await context.SaveChangesAsync();
            }
            
            var enrollment = new EnrollmentDto
            {
                Student = student,
                Course = course,
                EnrollmentDate = DateTime.UtcNow
            };

            context.Enrollments.Add(enrollment);

            enrollmentInfos.Add(new EnrollmentStudentDto()
            {
                Id = student.ID,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                EnrollmentDate = enrollment.EnrollmentDate
            });
        }

        await context.SaveChangesAsync();

        return new CourseResponseDto()
        {
            Message = "Kurs został utworzony i studenci zostali zapisani.",
            Course = new CourseDto
            {
                Id = course.Id,
                Title = course.Title,
                Credits = course.Credits,
                Teacher = course.Teacher
            },
            Enrollments = enrollmentInfos
        };
    }
}
 