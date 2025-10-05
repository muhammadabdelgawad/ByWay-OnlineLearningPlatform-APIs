using ByWay.Domain.Entities;

namespace ByWay.Application.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public AdminService(IUnitOfWork unitOfWork,
            IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<bool> CreateCourseAsync(CreateCourseRequest request)
        {
            try
            {
                var instructor = await _unitOfWork.Instructors.GetByIdAsync(request.InstructorId);
                if (instructor == null) return false;

                var course = _mapper.Map<Course>(request);
                await _unitOfWork.Courses.AddAsync(course);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<InstructorResponse> CreateInstructorAsync(CreateInstructorRequest request)
        {
            var instructor = _mapper.Map<Instructor>(request);
            await _unitOfWork.Instructors.AddAsync(instructor);
            await _unitOfWork.CompleteAsync();
            return  _mapper.Map<InstructorResponse>(instructor);
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            try
            {
                var course = await _unitOfWork.Courses.GetByIdAsync(courseId);
                if (course == null) return false;

                _unitOfWork.Courses.Delete(course);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteInstructorAsync(int instructorId)
        {
            try
            {
                var instructor = await _unitOfWork.Instructors.GetByIdAsync(instructorId);
                if (instructor == null) return false;

                _unitOfWork.Instructors.Delete(instructor);
                await _unitOfWork.CompleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<InstructorResponse>> GetAllInstructorsAsync()
        {
            var instructors = await _unitOfWork.Instructors.GetAllAsync();
            return _mapper.Map<IEnumerable<InstructorResponse>>(instructors);
        }

        public async Task<AdminDashboardDto> GetDashboardStatsAsync()
        {
            var instructors = await _unitOfWork.Instructors.GetAllAsync();
            var courses = await _unitOfWork.Courses.GetAllAsync();

            return new AdminDashboardDto
            {
                TotalInstructors = instructors.Count(),
                TotalCourses = courses.Count(),
                TotalUsers = _userManager.Users.Count(),
                TotalEnrollments = 0,  
                LastLoginDate = DateTime.UtcNow
            };
        }

        public async Task<bool> IsAdminAsync(ClaimsPrincipal user)
        {
            var currentUser = await _userManager.GetUserAsync(user);
            if (currentUser == null)
                return false;
            var roles = await _userManager.GetRolesAsync(currentUser);
            return roles.Contains("Admin");
        }
    
    
    }
}
