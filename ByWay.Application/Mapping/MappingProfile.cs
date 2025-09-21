using AutoMapper;
using ByWay.Application.DTOs.Course;
using ByWay.Application.DTOs.Instructor;
using ByWay.Domain.Entities;
using ByWay.Domain.Enums;

namespace ByWay.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Instructor, InstructorResponse>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate.ToString()))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle.ToString()));

            CreateMap<CreateInstructorRequest, Instructor>()
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => Enum.Parse<Rate>(src.Rate)))
                .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => Enum.Parse<JobTitle>(src.JobTitle)))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Courses, opt => opt.Ignore());

          
            CreateMap<Course, CourseResponse>();
            CreateMap<CreateCourseRequest, Course>();
            CreateMap<UpdateCourseRequest, Course>();
        }
    }
}
