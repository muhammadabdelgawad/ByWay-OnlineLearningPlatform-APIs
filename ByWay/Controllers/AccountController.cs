using AutoMapper;
using ByWay.Application.Abstraction.DTOs.Auth;
using ByWay.Application.Contracts;
using ByWay.Application.Services.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ByWay.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IMapper mapper, IUnitOfWork unitOfWork, IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto) 
        {
            var user = await authService.RegisterAsync(registerDto);
            if (user is null)
                return BadRequest(user);

            return Ok(user);
        }

    }
}
