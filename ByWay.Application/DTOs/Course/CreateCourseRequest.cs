using ByWay.Domain.Enums;

namespace ByWay.Application.DTOs.Course
{
    public class CreateCourseRequest
    {
        public string CourseName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Rate { get; set; }
        public string Certification { get; set; }
        public double TotalHours { get; set; }

        public string Level { get; set; }
        public string Category { get; set; }
        public string Instructor { get; set; }

    }
}
