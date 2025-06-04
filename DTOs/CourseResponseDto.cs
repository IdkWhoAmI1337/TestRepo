namespace WebApplication1.DTOs;

public class CourseResponseDto
{
    public string Message { get; set; } = null!;
    public CourseDto Course { get; set; } = null!;
    public List<EnrollmentStudentDto> Enrollments { get; set; } = null!;
}