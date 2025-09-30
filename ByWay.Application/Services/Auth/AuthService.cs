using AutoMapper;
using ByWay.Application.Abstraction.DTOs.Auth;
using ByWay.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ByWay.Application.Services.Auth
{
    public class AuthService(IMapper mapper, IOptions<JwtSettings> jwtSettings,
        UserManager<ApplicationUser> userManager) : IAuthService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var existUser = await userManager.FindByEmailAsync(registerDto.Email);
            if(existUser != null)
               throw new Exception($"Email {registerDto.Email} is already registered");

            existUser= await userManager.FindByNameAsync(registerDto.UserName);
            if (existUser != null)
                throw new Exception($"Username {registerDto.UserName} is already Taken");

            var user = new ApplicationUser
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                DisplayName = registerDto.DisplayName
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            //  throw new Exception("Failed to create user, please try again");
              {
                  var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                  throw new Exception($"Failed to create user: {errors}");
              }
            var response= new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token = await GenerateTokenAsync(user)
            };
            return response;

        }

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            var user = await userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                throw new UnauthorizedAccessException("Invalid email or password");
            
            var result = await userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!result)
                throw new UnauthorizedAccessException("Invalid email or password");
        
            if (!user.IsActive)
                throw new UnauthorizedAccessException("Account is deactivated");
            
            var response = new UserDto
            {
                Id = user.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user)
            };
            
            return response;
        }

        public async Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal claimsPrincipal)
        {
            var email = claimsPrincipal.FindFirstValue(ClaimTypes.Email);
            if(string.IsNullOrEmpty(email))
                throw new Exception("Invalid Mail");

            var user =await  userManager.FindByEmailAsync(email!);
            if (user == null)
                throw new Exception("User not found");

            var response = new UserDto
            {
                Id = user!.Id,
                DisplayName = user.DisplayName,
                Email = user.Email!,
                Token = await GenerateTokenAsync(user)
            };

            return response;

        }


        public async Task<bool> UserExistsAsync(string email)
        {
            return await userManager.FindByEmailAsync(email) != null;

        }

        public async Task<string> GenerateTokenAsync(ApplicationUser applicationUser) 
        {
            var userClaims= await userManager.GetClaimsAsync(applicationUser);

            var roles = await userManager.GetRolesAsync(applicationUser);

            var rolesAsClaim = roles.Select(role => new Claim(ClaimTypes.Role, role));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,applicationUser.Id),
                new Claim(ClaimTypes.Email,applicationUser.Email!),
                new Claim(ClaimTypes.Name,applicationUser.DisplayName),
            }.Union(userClaims)
             .Union(rolesAsClaim);


            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: _jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
               expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
               claims: claims,
               signingCredentials: signingCredentials
           );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }










    }
}
