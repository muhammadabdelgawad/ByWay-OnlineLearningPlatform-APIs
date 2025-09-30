using Microsoft.AspNetCore.Identity;

namespace ByWay.Domain.Entities.Identity
{
    public class ApplicationUser :IdentityUser
    {
        public required string DisplayName { get; set; }
        public string? PictureUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; } 
        public virtual ICollection<CourseEnrollment> CourseEnrollments { get; set; } = new List<CourseEnrollment>();


    }
}
