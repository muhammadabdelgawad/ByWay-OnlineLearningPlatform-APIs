namespace ByWay.Domain.Entities
{
    public class Category 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }= string.Empty;
        public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
