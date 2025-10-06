using ByWay.Application.Abstraction.DTOs.Common;

namespace ByWay.Application.Abstraction.DTOs.Course
{
    public class CourseFilterRequest : PagedRequest
    {
        public string? CourseName { get; set; }
        public string? Level { get; set; }
        public int? CategoryId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        
    }
}