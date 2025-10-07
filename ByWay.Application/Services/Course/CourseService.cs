using ByWay.Application.Abstraction.Repositories.Course;

namespace ByWay.Application.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

    }
}
