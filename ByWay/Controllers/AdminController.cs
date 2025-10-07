
namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] 
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
        public async Task<ActionResult> GetAllInstructors([FromQuery] InstructorFilterRequest request)
        {
            var instructors = await _adminService.GetAllInstructorsAsync(request);
            return Ok(instructors);
        }

        [HttpGet("courses")]
        public async Task<ActionResult> GetAllCourses([FromQuery] CourseFilterRequest request)
        {
            var courses = await _adminService.GetAllCoursesAsync(request);
            return Ok(courses);
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
