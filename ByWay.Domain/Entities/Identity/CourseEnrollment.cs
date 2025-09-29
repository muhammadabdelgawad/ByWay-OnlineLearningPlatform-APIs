namespace ByWay.Domain.Entities.Identity
{
    public class CourseEnrollment
    {
        public string UserId { get; set; } = string.Empty; // Add this back - it's required for foreign key
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletionDate { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}
