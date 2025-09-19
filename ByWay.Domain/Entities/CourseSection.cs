namespace ByWay.Domain.Entities
{
    public class CourseSection : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int SectionNumber { get; set; }
        public int LecturesCount { get; set; }
        public TimeOnly TotalDuration { get; set; }
        
        public int CourseId { get; set; }
        
        public virtual Course Course { get; set; } = null!;
        public virtual ICollection<Lectur> Lectures { get; set; } = new List<Lectur>();
    }
}