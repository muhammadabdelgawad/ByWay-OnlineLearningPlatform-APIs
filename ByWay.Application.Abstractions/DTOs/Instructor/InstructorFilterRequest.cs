using ByWay.Application.Abstraction.DTOs.Common;

namespace ByWay.Application.Abstraction.DTOs.Instructor
{
    public class InstructorFilterRequest : PagedRequest
    {
        public string? Name { get; set; }
        public string? JobTitle { get; set; }
        public string? Rate { get; set; }
    }
}