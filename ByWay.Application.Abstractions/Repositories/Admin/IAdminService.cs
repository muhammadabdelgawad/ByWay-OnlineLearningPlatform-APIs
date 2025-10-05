
namespace ByWay.Application.Abstractions.Admin
{
    public interface IAdminService
    {
        Task<bool> IsAdminAsync(ClaimsPrincipal user);
        Task<AdminDashboardDto> GetDashboardStatsAsync();
        Task<InstructorResponse> CreateInstructorAsync(CreateInstructorRequest request);
        Task<bool> CreateCourseAsync(CreateCourseRequest request);
        Task<IEnumerable<InstructorResponse>> GetAllInstructorsAsync();
        Task<bool> DeleteInstructorAsync(int instructorId);
        Task<bool> DeleteCourseAsync(int courseId);
    }
}