using Microsoft.AspNetCore.Identity;
namespace ByWay.Domain.Entities.Identity

{
    public class CourseEnrollment
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletionDate { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
    }
}
