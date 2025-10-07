namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] 
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _adminService = adminService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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


        [HttpPut("instructors/{id}")]
        public async Task<ActionResult> UpdateInstructor(int id, [FromBody] UpdateInstructorRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("Instructor Id Not Exists");
            }
            var instructor = await _unitOfWork.Instructors.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            _mapper.Map(request, instructor);
            _unitOfWork.Instructors.Update(instructor);
            await _unitOfWork.CompleteAsync();
            var result = _mapper.Map<InstructorResponse>(instructor);
            return Ok(result);
        }

       
        [HttpPut("courses/{id}")]
        public async Task<ActionResult> UpdateCourse(int id, [FromBody] UpdateCourseRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest("Course Id Not Exists");
            }
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            _mapper.Map(request, course);
            _unitOfWork.Courses.Update(course);
            await _unitOfWork.CompleteAsync();
            return Ok("Updated Successfully");
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
