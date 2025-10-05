using ByWay.Application.Abstraction.DTOs.Course;
using ByWay.Application.Abstraction.DTOs.Instructor;
using ByWay.Application.Abstractions.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboard()
        {
            var isAdmin = await _adminService.IsAdminAsync(User);
            if (!isAdmin)
            {
                return Forbid("Access denied. Admin role required.");
            }

            var dashboardStats = await _adminService.GetDashboardStatsAsync();
            return Ok(dashboardStats);
        }

        [HttpPost("instructors")]
        public async Task<IActionResult> CreateInstructor([FromBody] CreateInstructorRequest request)
        {
            var instructor = await _adminService.CreateInstructorAsync(request);
            return Ok(instructor);
        }

        [HttpPost("courses")]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request)
        {
            var success = await _adminService.CreateCourseAsync(request);
            if (!success)
            {
                return BadRequest("Failed to create course. Please verify instructor exists.");
            }
            return Ok("Course created successfully");
        }

        [HttpGet("instructors")]
        public async Task<IActionResult> GetAllInstructors()
        {
            var instructors = await _adminService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        [HttpDelete("instructors/{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var success = await _adminService.DeleteInstructorAsync(id);
            if (!success)
            {
                return NotFound("Instructor not found");
            }
            return Ok("Deleted Successfully");
        }

        [HttpDelete("courses/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var success = await _adminService.DeleteCourseAsync(id);
            if (!success)
            {
                return NotFound("Course not found");
            }
            return Ok("Deleted Successfully");
        }
    }
}
