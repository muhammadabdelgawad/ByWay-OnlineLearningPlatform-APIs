namespace ByWay.Application.Abstraction.Repositories.Course
{
    public interface ICourseService
    {
        Task<PagedResult<CourseResponse>> GetAllCoursesAsync(CourseFilterRequest request);

    }
}
