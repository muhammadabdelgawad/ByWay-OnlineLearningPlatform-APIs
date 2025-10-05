namespace ByWay.Application.Abstraction.DTOs.Admin
{
    public class AdminDashboardDto
    {
        public int TotalInstructors { get; set; }
        public int TotalCourses { get; set; }
        public int TotalUsers { get; set; }
        public int TotalEnrollments { get; set; }
        public DateTime LastLoginDate { get; set; }
    }
}