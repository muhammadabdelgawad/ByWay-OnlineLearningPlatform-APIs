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
                .ForMember(d => d.Rate, o => o.MapFrom(s => s.Rate.ToString()))
                .ForMember(d => d.JobTitle, o => o.MapFrom(s => s.JobTitle.ToString()));

            CreateMap<CreateInstructorRequest, Instructor>()
                .ForMember(d => d.Rate, o => o.MapFrom(s => Enum.Parse<Rate>(s.Rate)))
                .ForMember(d => d.JobTitle, o => o.MapFrom(s => Enum.Parse<JobTitle>(s.JobTitle)))
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Courses, o => o.Ignore());
          
            CreateMap<UpdateInstructorRequest, Instructor>()
                .ForMember(d => d.Rate, o => o.MapFrom(s => Enum.Parse<Rate>(s.Rate)))
                .ForMember(d => d.JobTitle, o => o.MapFrom(s => Enum.Parse<JobTitle>(s.JobTitle)))
                .ForMember(d => d.Courses, o => o.Ignore());  
 
            CreateMap<Course, CourseResponse>()
                .ForMember(d => d.Level, o => o.MapFrom(s => s.Level.ToString()))
                .ForMember(d => d.Rate, o => o.MapFrom(s => s.Rate.ToString()))
                .ForMember(d => d.Category, o => o.MapFrom(s => s.CategoryId))
                .ForMember(d => d.Instructor, o => o.MapFrom(s => s.InstructorId));    

            CreateMap<CreateCourseRequest, Course>()
                .ForMember(d => d.Level, o => o.MapFrom(s => Enum.Parse<Level>(s.Level)))
                .ForMember(d => d.Category, o => o.Ignore())                                  
                .ForMember(d => d.Instructor, o => o.Ignore())  
                .ForMember(d => d.Sections, o => o.Ignore())
                .ForMember(d => d.Lectures, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore());

            CreateMap<UpdateCourseRequest, Course>()
                .ForMember(d => d.Level, o => o.MapFrom(s => Enum.Parse<Level>(s.Level)))
                .ForMember(d => d.Category, o => o.Ignore())                                  
                .ForMember(d => d.Instructor, o => o.Ignore())
                .ForMember(d => d.Sections, o => o.Ignore())
                .ForMember(d => d.Lectures, o => o.Ignore())
                .ForMember(d => d.Id, o => o.Ignore());
        }
    }
}
