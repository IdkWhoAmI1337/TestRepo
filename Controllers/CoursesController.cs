using System.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/api/[controller]//with-enrollments")]
public class CoursesController(ICourseService service): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCourse()
    {
        try
        {
            return Ok(await service.CreateCourse());
        }
        catch (DbException e)
        {
            return BadRequest(e.Message);
        }
    }
}