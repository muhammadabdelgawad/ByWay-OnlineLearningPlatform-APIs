using AutoMapper;
using ByWay.Application.Contracts;
using ByWay.Application.DTOs.Instructor;
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
    }
}
