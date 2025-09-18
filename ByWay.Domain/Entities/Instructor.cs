namespace ByWay.Domain.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; } = string.Empty;

        public Rate Rate { get; set; }
        public JobTitle JobTitle { get; set; }

        public virtual ICollection<Course> Courses { get; set; } = new List<Course>(); 
    }
}