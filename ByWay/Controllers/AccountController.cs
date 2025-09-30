using AutoMapper;
using ByWay.Application.Abstraction.DTOs.Auth;
using ByWay.Application.Contracts;
using ByWay.Application.Services.Auth;
using Microsoft.AspNetCore.Authorization;
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
           
            return Ok(user);
        }

        [Authorize]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var user = await authService.LoginAsync(loginDto);
            return Ok(user);
        }

        [Authorize]
        [HttpGet("currentUser")]
        public async Task<ActionResult> GetCurrentUser()
        {
            var user = await authService.GetCurrentUserAsync(User);
            return Ok(user);
        }

        [HttpGet("emailExists")]
        public async Task<ActionResult> CheckEmailExists(string email)
        {
            var exists = await authService.UserExistsAsync(email);
            return Ok(exists);
        }


    }
}
