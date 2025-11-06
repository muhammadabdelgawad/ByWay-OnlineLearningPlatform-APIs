namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ICourseService _courseService;
        public CourseController(IUnitOfWork unitOfWork, IMapper mapper , ICourseService courseService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _courseService = courseService;
        }


        [HttpGet]
        public async Task<ActionResult> GetAllCourses([FromQuery] CourseFilterRequest request)
        {
            var courses = await _courseService.GetAllCoursesAsync(request);
            return Ok(courses);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = _mapper.Map<CourseResponse>(await _unitOfWork.Courses.GetByIdAsync(id));
            return Ok(course);
        }
    }
}
