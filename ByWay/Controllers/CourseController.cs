using AutoMapper;
using ByWay.Application.Contracts;
using ByWay.Application.DTOs.Course;
using ByWay.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CourseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = _mapper.Map<IEnumerable<CourseResponse>>(await _unitOfWork.Courses.GetAllAsync());
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = _mapper.Map<CourseResponse>(await _unitOfWork.Courses.GetByIdAsync(id));
            return Ok(course);
        }



        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody]CreateCourseRequest request)
        {
            var course = _mapper.Map<Course>(request);
            await _unitOfWork.Courses.AddAsync(course);
            await _unitOfWork.CompleteAsync();
            return Ok("Created Successfuly");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id) 
        {
            var course = await _unitOfWork.Courses.GetByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
             _unitOfWork.Courses.Delete(course);
            await _unitOfWork.CompleteAsync();
            return Ok("Deleted Successfully");
        }
    }
}
