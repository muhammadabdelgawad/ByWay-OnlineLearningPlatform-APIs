using AutoMapper;
using ByWay.Application.Contracts;
using ByWay.Application.DTOs.Instructor;
using ByWay.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstuctorController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAllInstructors()
        {
            var result = _mapper.Map<IEnumerable<InstructorResponse>>(await _unitOfWork.Instructors.GetAllAsync());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetInstructorById(int id)
        {
            var instructor = await _unitOfWork.Instructors.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<InstructorResponse>(instructor);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateInstructor([FromBody] CreateInstructorRequest request)
        {
            var instructor = _mapper.Map<Instructor>(request);

            await _unitOfWork.Instructors.AddAsync(instructor);
            await _unitOfWork.CompleteAsync();
            
            return Ok(request);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateInstructor(int id, [FromBody] UpdateInstructorRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest(" Instructor Id Not Exists");
            }
            var instructor = await _unitOfWork.Instructors.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            _mapper.Map(request, instructor);
            _unitOfWork.Instructors.Update(instructor);
            await _unitOfWork.CompleteAsync();
            var result = _mapper.Map<InstructorResponse>(instructor);
            return Ok(result);
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            var instructor = await _unitOfWork.Instructors.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            _unitOfWork.Instructors.Delete(instructor);
            await _unitOfWork.CompleteAsync();
            return Ok("Deleted Successfuly");
        }
    }
}
