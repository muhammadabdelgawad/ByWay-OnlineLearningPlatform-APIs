namespace ByWay.Domain.Entities
{
    public class Lectur

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(10);
        public bool IsCompeleted { get; set; } = false;
        public int SectionId { get; set; }
        public int CourseId { get; set; }

        public virtual CourseSection CourseSection { get; set; }= null!;
        public virtual Course Course { get; set; }= null!;

    }
}
