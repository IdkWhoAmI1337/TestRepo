namespace WebApplication1.DTOs;

public class CourseRequestDto
{
    public string Title { get; set; } = null!;
    public string Credits { get; set; } = null!;
    public string Teacher { get; set; } = null!;
    public List<StudentDto> Students { get; set; } = null!;
}
