namespace ByWay.Domain.Entities
{
    public class Lecture: BaseEntity
    {
        public string Name { get; set; }
        public TimeSpan Duration { get; set; } = TimeSpan.FromMinutes(10);
    }
}
