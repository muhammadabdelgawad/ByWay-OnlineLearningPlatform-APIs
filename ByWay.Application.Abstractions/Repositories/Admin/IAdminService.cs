
namespace ByWay.Application.Abstractions.Admin
{
    public interface IAdminService
    {
        Task<bool> IsAdminAsync(ClaimsPrincipal user);
        Task<AdminDashboardDto> GetDashboardStatsAsync();
        Task<InstructorResponse> CreateInstructorAsync(CreateInstructorRequest request);
        Task<bool> CreateCourseAsync(CreateCourseRequest request);
        Task<PagedResult<InstructorResponse>> GetAllInstructorsAsync(InstructorFilterRequest request);
        Task<PagedResult<CourseResponse>> GetAllCoursesAsync(CourseFilterRequest request);
        Task<bool> DeleteInstructorAsync(int instructorId);
        Task<bool> DeleteCourseAsync(int courseId);
    }
}