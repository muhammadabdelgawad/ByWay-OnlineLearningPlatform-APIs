namespace ByWay.Domain.Entities;
public class Course : BaseEntity
{
    public string CourseName { get; set; }
    public string PictureUrl { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string Certification { get; set; }
    public double TotalHours { get; set; }

    public Level Level { get; set; }

    public int CategoryId { get; set; }
    public int InstructorId { get; set; }
    public ICollection<CourseSection> Sections { get; set; } = new List<CourseSection>();

    public virtual Category Category { get; set; } = null!;
    public virtual Instructor Instructor { get; set; } = null!;
}
