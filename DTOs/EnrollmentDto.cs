namespace WebApplication1.DTOs;

public class EnrollmentDto
{
    public StudentDto Student { get; set; }
    public CourseDto Course { get; set; }
    public DateTime EnrollmentDate { get; set; }

}
