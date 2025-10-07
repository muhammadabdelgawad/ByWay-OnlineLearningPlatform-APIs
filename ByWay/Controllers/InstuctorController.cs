using ByWay.Domain.Entities;

namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstuctorController(IUnitOfWork unitOfWork, IMapper mapper) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

       

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
