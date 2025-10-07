namespace ByWay.Application.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<ApplicationUser> userManager)
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

                var course = _mapper.Map<Domain.Entities.Course>(request);
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
            return _mapper.Map<InstructorResponse>(instructor);
        }

       
        public async Task<PagedResult<InstructorResponse>> GetAllInstructorsAsync(InstructorFilterRequest request)
        {
            var instructors = await _unitOfWork.Instructors.GetAllAsync();

           
            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                instructors = instructors.Where(i => 
                    i.Name.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                    i.Description.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));
            }

            
            if (!string.IsNullOrEmpty(request.Name))
            {
                instructors = instructors.Where(i => 
                    i.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(request.Rate))
            {
                if (Enum.TryParse<Rate>(request.Rate, out var parsedRate))
                {
                    instructors = instructors.Where(i => i.Rate == parsedRate);
                }
            }

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                instructors = request.SortBy.ToLower() switch
                {
                    "name" => request.SortDirection?.ToLower() == "desc" 
                        ? instructors.OrderByDescending(i => i.Name)
                        : instructors.OrderBy(i => i.Name),
                    "jobtitle" => request.SortDirection?.ToLower() == "desc"
                        ? instructors.OrderByDescending(i => i.JobTitle)
                        : instructors.OrderBy(i => i.JobTitle),
                    "rate" => request.SortDirection?.ToLower() == "desc"
                        ? instructors.OrderByDescending(i => i.Rate)
                        : instructors.OrderBy(i => i.Rate),
                    _ => instructors.OrderBy(i => i.Name)
                };
            }
            else
            {
                instructors = instructors.OrderBy(i => i.Name);
            }

            var totalCount = instructors.Count();

         
            var pagedInstructors = instructors
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            return new PagedResult<InstructorResponse>
            {
                Data = _mapper.Map<IEnumerable<InstructorResponse>>(pagedInstructors),
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
        }

        public async Task<PagedResult<CourseResponse>> GetAllCoursesAsync(CourseFilterRequest request)
        {
            var courses = await _unitOfWork.Courses.GetAllAsync();

            if (!string.IsNullOrEmpty(request.SearchTerm))
            {
                courses = courses.Where(c =>
                    c.CourseName.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase) ||
                    c.Description.Contains(request.SearchTerm, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(request.CourseName))
            {
                courses = courses.Where(c =>
                    c.CourseName.Contains(request.CourseName, StringComparison.OrdinalIgnoreCase));
            }

            if (request.CategoryId.HasValue)
            {
                courses = courses.Where(c => c.CategoryId == request.CategoryId.Value);
            }

            if (request.MinPrice.HasValue)
            {
                courses = courses.Where(c => c.Price >= request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                courses = courses.Where(c => c.Price <= request.MaxPrice.Value);
            }

            if (!string.IsNullOrEmpty(request.SortBy))
            {
                courses = request.SortBy.ToLower() switch
                {
                    "coursename" => request.SortDirection?.ToLower() == "desc"
                        ? courses.OrderByDescending(c => c.CourseName)
                        : courses.OrderBy(c => c.CourseName),
                    "price" => request.SortDirection?.ToLower() == "desc"
                        ? courses.OrderByDescending(c => c.Price)
                        : courses.OrderBy(c => c.Price),
                    "totalhours" => request.SortDirection?.ToLower() == "desc"
                        ? courses.OrderByDescending(c => c.TotalHours)
                        : courses.OrderBy(c => c.TotalHours),
                    _ => courses.OrderBy(c => c.CourseName)
                };
            }
            else
            {
                courses = courses.OrderBy(c => c.CourseName);
            }

            var totalCount = courses.Count();

            var pagedCourses = courses
                .Skip((request.PageNumber - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToList();

            return new PagedResult<CourseResponse>
            {
                Data = _mapper.Map<IEnumerable<CourseResponse>>(pagedCourses),
                TotalCount = totalCount,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };
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

    }
}
