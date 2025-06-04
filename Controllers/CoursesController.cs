using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/api/[controller]//with-enrollments")]
public class CoursesController(ICourseService service): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CourseRequestDto request)
    {
        try
        {
            return Ok(await service.CreateCourse(request));
        }
        catch (DbException e)
        {
            return BadRequest(e.Message);
        }
    }
}