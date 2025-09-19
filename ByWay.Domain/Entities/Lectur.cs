namespace ByWay.Domain.Entities
{
    public class Lectur
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(10);
        public bool IsCompeleted { get; set; } = false;
        public int SectionId { get; set; }

        public virtual CourseSection CourseSection { get; set; }= null!;

    }
}
