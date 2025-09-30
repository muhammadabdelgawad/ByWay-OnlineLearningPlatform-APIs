namespace ByWay.Application.Abstraction.DTOs.Instructor
{
    public class CreateInstructorRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; } = string.Empty;

        public string Rate { get; set; }
        public string JobTitle { get; set; }
    }
}
