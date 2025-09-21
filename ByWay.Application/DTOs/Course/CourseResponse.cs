namespace ByWay.Application.DTOs.Course
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public string Certification { get; set; }
        public double TotalHours { get; set; }
        public string Level { get; set; }
        public int Category { get; set; }
        public int Instructor { get; set; }
    }
}
