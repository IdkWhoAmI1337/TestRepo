using System.Data.Common;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class EnrollmentsController(IEnrollmentService service): ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetEnrollments()
    {
        try
        {
            return Ok(await service.GetEnrollment());
        }
        catch (DbException e)
        {
            return BadRequest(e.Message);
        }
    }
}