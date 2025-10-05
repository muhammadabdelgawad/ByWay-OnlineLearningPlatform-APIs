using ByWay.Application.Abstraction.DTOs.Course;
using ByWay.Application.Abstraction.DTOs.Instructor;
using ByWay.Application.Abstractions.Admin;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminOnly")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("dashboard")]
        public async Task<ActionResult> GetDashboard()
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
        public async Task<ActionResult> CreateInstructor([FromBody] CreateInstructorRequest request)
        {
            var instructor = await _adminService.CreateInstructorAsync(request);
            return Ok(instructor);
        }

        [HttpPost("courses")]
        public async Task<ActionResult> CreateCourse([FromBody] CreateCourseRequest request)
        {
            var success = await _adminService.CreateCourseAsync(request);
            if (!success)
            {
                return BadRequest("Failed to create course. Please verify instructor exists.");
            }
            return Ok("Course created successfully");
        }

        [HttpGet("instructors")]
        public async Task<ActionResult> GetAllInstructors()
        {
            var instructors = await _adminService.GetAllInstructorsAsync();
            return Ok(instructors);
        }

        [HttpDelete("instructors/{id}")]
        public async Task<ActionResult> DeleteInstructor(int id)
        {
            var success = await _adminService.DeleteInstructorAsync(id);
            if (!success)
            {
                return NotFound("Instructor not found");
            }
            return Ok("Deleted Successfully");
        }

        [HttpDelete("courses/{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
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
